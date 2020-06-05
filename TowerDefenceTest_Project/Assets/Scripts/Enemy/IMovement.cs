using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement 
{
    Vector3 Position { get; set; }
    float Speed { get; }
    void EndPointReached();
    void Destroy();
}
