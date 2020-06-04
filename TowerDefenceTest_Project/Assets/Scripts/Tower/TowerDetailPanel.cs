using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TowerDetailPanel : MonoBehaviour
{
    [SerializeField] private Transform UpgradePanel;
    [SerializeField] private Text DamageText;
    [SerializeField] private Text RangeText;
    [SerializeField] private Text AttackSpeedText;

    public void Setup(Tower tower)
    {
        DamageText.text = tower.Damage.ToString("F0");
        RangeText.text = tower.Range.ToString("F1");
        AttackSpeedText.text = tower.AttackSpeed.ToString("F1");

        ClearUpgrades();
        foreach(var upgrade in tower.UpgradeList.OrderBy(x=>x.Type))
        {
            var button = Instantiate(GameAssets.I.UpgradeButton);
            button.Setup(upgrade);
            button.transform.SetParent(UpgradePanel);
        }

        gameObject.SetActive(true);
    }

    private void ClearUpgrades()
    {
        foreach(Transform child in UpgradePanel)
        {
            Destroy(child.gameObject);
        }
    }
}
