using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILookingForTargetBehaviour
{
    bool IsChangeTargetNeeded(Tower tower, ITarget enemy);
}
