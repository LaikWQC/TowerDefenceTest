using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    Vector3 Position { get; set; }
    bool IsAlive { get; }
    void TakeDamage(float damage);
}
