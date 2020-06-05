using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LookingForTargetBehaviourFactory
{
   public static  ILookingForTargetBehaviour GetBehaviour()
    {
        return new LookingForTargetBehaviour_findNew();
        //return new LookingForTargetBehaviour_lockTarget();
    }
}
