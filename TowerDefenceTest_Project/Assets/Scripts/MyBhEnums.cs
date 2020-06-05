using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBhEnums 
{
    public enum FindTarget
    {
        Closest,
        MaxHp,
        MinHp
    }

    public enum LookingForTarget
    {
        FindNew,
        LockTarget
    }

    public enum ShowDamage
    {
        NoText
    }

    public enum Death
    {
        Destroy
    }

    public enum Movement
    {
        Waypoints
    }

    public enum Reach
    {
        Destroy
    }
}
