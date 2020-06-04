using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_AddDamage : Upgrade
{
    private float damage;
    public Upgrade_AddDamage(Tower tower, int price, float damage) : base(tower, price)
    {
        this.damage = damage;
        type = MyEnums.UpgradeType.AddDamage;
    }

    public override string Description => $"Damage +{damage}";

    public override void Activate()
    {
        if(ResourcesManager.I.Buy(price))
        {
            tower.Damage += damage;
            tower.UpgradeList.Remove(this);
            tower.UpgradeList.Add(new Upgrade_AddDamage(tower, price + DefaultValues.I.DamageUpgradePriceIncrease, damage));
            AfterActivated();
        }
    }
}
