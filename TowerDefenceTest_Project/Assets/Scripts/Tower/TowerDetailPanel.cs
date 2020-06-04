using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerDetailPanel : MonoBehaviour
{
    [SerializeField] private Text DamageText;
    [SerializeField] private Text RangeText;
    [SerializeField] private Text AttackSpeedText;

    public void Setup(float damage, float range, float attackSpeed)
    {
        DamageText.text = damage.ToString();
        RangeText.text = range.ToString();
        AttackSpeedText.text = attackSpeed.ToString();
        gameObject.SetActive(true);
    }
}
