using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private static Settings i;
    
    void Awake()
    {
        i = this;
    }

    public static Settings I => i;

    public MyBhEnums.FindTarget FindTargetBh;
    public MyBhEnums.LookingForTarget LookingBh;
    public MyBhEnums.ShowDamage ShowDamageBh;
    public MyBhEnums.Movement MovementBh;
    public MyBhEnums.Death DeathBh;
    public MyBhEnums.Reach ReachBh;
}
