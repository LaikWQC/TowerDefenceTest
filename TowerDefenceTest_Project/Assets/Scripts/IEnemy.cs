using UnityEngine;

public interface IEnemy
{
    Vector3 Position { get; }
    bool IsAlive { get; }
    void TakeDamage(float damage);
}
