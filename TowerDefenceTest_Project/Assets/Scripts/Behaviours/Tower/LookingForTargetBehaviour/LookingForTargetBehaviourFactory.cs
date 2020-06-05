using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LookingForTargetBehaviourFactory
{
   public static  ILookingForTargetBehaviour GetBehaviour()
    {
        switch(Settings.I.LookingBh)
        {
            case MyBhEnums.LookingForTarget.FindNew:
                return new LookingForTargetBehaviour_findNew();
            case MyBhEnums.LookingForTarget.LockTarget:
                return new LookingForTargetBehaviour_lockTarget();

            default:
                return new LookingForTargetBehaviour_findNew();
        }
    }
}
