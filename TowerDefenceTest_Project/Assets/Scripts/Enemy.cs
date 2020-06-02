using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private int waypointIndex;
    private Transform destination;

    void Start()
    {
        waypointIndex = 0;
        destination = GameManager.I.GetDestination(waypointIndex);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        if(Vector2.Distance(destination.position, transform.position) < 0.05f)
        {
            destination = GameManager.I.GetDestination(++waypointIndex);
            if (destination == null)
                EndPointReached();
        }
    }

    private void EndPointReached()
    {
        Destroy(gameObject);
    }
}
