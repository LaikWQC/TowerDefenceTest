using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForTargetBehaviour_findNew : ILookingForTargetBehaviour
{
    public bool IsChangeTargetNeeded(ITower tower, ITarget enemy)
    {
        return true;
    }
}
