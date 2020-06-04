using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_AddSpeed : Upgrade
{
    private float attackSpeed;
    public Upgrade_AddSpeed(Tower tower, int price, float attackSpeed) : base(tower, price)
    {
        this.attackSpeed = attackSpeed;
        type = MyEnums.UpgradeType.AddSpeed;
    }

    public override string Description => $"Attack speed +{attackSpeed}";

    public override void Activate()
    {
        if (ResourcesManager.I.Buy(price))
        {
            tower.AttackSpeed += attackSpeed;
            tower.UpgradeList.Remove(this);
            tower.UpgradeList.Add(new Upgrade_AddSpeed(tower, price + 2, attackSpeed));
            AfterActivated();
        }
    }
}