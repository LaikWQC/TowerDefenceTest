using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public Transform GetWaypoint(int index)
    {
        if (index < waypoints.Length)
            return waypoints[index];
        else
            return null;
    }

    public Vector3 StartLocation => waypoints[0].position;
}
