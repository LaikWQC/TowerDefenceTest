using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade 
{
    protected MyEnums.UpgradeType type;
    protected Tower tower;
    protected int price;

    public Upgrade(Tower tower, int price)
    {
        this.tower = tower;
        this.price = price;
    }

    protected void AfterActivated()
    {
        TowerManager.I.UpdatePanel();
    }

    public abstract void Activate();
    public MyEnums.UpgradeType Type => type;
    public int Price => price;
    public abstract string Description { get; }
}
