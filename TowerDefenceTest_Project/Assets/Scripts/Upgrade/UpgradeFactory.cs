using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeFactory
{
    public static List<Upgrade> GetUpgrades(Tower tower)
    {
        return new List<Upgrade>()
        {
            CreateNew(MyEnums.UpgradeType.AddDamage, tower),
            CreateNew(MyEnums.UpgradeType.AddSpeed, tower)
        };
    }

    private static Upgrade CreateNew(MyEnums.UpgradeType type, Tower tower)
    {
        switch(type)
        {
            case MyEnums.UpgradeType.AddDamage:
                return new Upgrade_AddDamage(tower, DefaultValues.I.DamageUpgradePrice, DefaultValues.I.DamageUpgradeValue);
            case MyEnums.UpgradeType.AddSpeed:
                return new Upgrade_AddSpeed(tower, DefaultValues.I.SpeedUpgradePrice, DefaultValues.I.SpeedUpgradeValue);
        }
        return null;
    }
}
