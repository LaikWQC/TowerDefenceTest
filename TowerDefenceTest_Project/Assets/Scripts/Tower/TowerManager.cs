using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : MonoBehaviour
{
    [SerializeField] TowerDetailPanel Details;

    private Tower selectedTower;
    private static TowerManager i;

    private void Awake()
    {
        i = this;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 256);
            var tower = hit.collider?.GetComponent<Tower>();
            if (tower != null)
            {
                if (tower != selectedTower)
                {
                    Select(tower);
                }
            }
            else
            {
                Unselect();
            }
        }
    }

    private void Select(Tower tower)
    {
        Unselect();
        tower.Selected = true;
        selectedTower = tower;
        Details.Setup(tower);
    }

    private void Unselect()
    {
        Details.gameObject.SetActive(false);
        if (selectedTower != null) selectedTower.Selected = false;
        selectedTower = null;
    }

    public void UpdatePanel()
    {
        if(selectedTower!=null)
            Details.Setup(selectedTower);
    }

    public static TowerManager I => i;
}
