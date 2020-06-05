using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindTargetBehaviourFactory
{
    public static IFindTargetBehaviour GetBehaviour()
    {
        return new FindTargetBehaviour_closest();
        //return new FindTargetBehaviour_minHp();
        //return new FindTargetBehaviour_maxHp();
    }
}
