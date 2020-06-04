using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] TowerDetailPanel Details;

    private Tower selectedTower; 
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
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
        tower.Select = true;
        selectedTower = tower;
        Details.Setup(tower.Damage, tower.Range, tower.AttackSpeed);
    }

    private void Unselect()
    {
        Details.gameObject.SetActive(false);
        if (selectedTower != null) selectedTower.Select = false;
        selectedTower = null;
    }
}
