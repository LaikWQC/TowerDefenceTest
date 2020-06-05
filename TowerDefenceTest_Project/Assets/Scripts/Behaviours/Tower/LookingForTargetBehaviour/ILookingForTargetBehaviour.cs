using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILookingForTargetBehaviour
{
    bool IsChangeTargetNeeded(ITower tower, ITarget enemy);
}
