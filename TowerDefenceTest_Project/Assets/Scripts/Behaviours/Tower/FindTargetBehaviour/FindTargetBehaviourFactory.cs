using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindTargetBehaviourFactory
{
    public static IFindTargetBehaviour GetBehaviour()
    {
        switch(Settings.I.FindTargetBh)
        {
            case MyBhEnums.FindTarget.Closest:
                return new FindTargetBehaviour_closest();
            case MyBhEnums.FindTarget.MinHp:
                return new FindTargetBehaviour_minHp();
            case MyBhEnums.FindTarget.MaxHp:
                return new FindTargetBehaviour_maxHp();

            default:
                return new FindTargetBehaviour_closest();
        }
    }
}
