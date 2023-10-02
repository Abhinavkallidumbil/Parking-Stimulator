using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{
    [Header("oppenent Car")]
    public OpponentCar opponentCar;
    public WayPoint CurrentWaypoint;

    private void Start()
    {
        opponentCar.LocateDestination(CurrentWaypoint.GetPosition());
    }
    private void FixedUpdate()
    {
        if (opponentCar.destinationReached)
        {
            CurrentWaypoint = CurrentWaypoint.nextWaypoint;
            opponentCar.LocateDestination(CurrentWaypoint.GetPosition());
        }
    }
}
