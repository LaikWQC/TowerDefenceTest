using UnityEngine;

public interface IEnemy
{
    Vector3 Position { get; set; }
    bool IsAlive { get; }
    float Speed { get; }
    void TakeDamage(float damage);
    void EndPointReached();
    void Destroy();
    void Setup(EnemyDummy dummy);
}
