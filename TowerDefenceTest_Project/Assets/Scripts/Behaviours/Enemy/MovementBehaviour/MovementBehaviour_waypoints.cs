using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour_waypoints : IEnemyBehaviour
{
    private IEnemy enemy;
    private int waypointIndex;
    private Transform destination;

    public MovementBehaviour_waypoints(IEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void StartBehaviour()
    {
        waypointIndex = 0;
        destination = GameManager.I.GetDestination(waypointIndex);
    }

    public void UpdateBehaviour()
    {
        enemy.Position = Vector2.MoveTowards(enemy.Position, destination.position, enemy.Speed * Time.deltaTime);

        if (Vector2.Distance(destination.position, enemy.Position) < 0.05f)
        {
            destination = GameManager.I.GetDestination(++waypointIndex);
            if (destination == null)
                enemy.EndPointReached();
        }
    }
}
