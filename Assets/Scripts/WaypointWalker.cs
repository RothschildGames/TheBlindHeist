using UnityEngine;
using System.Collections;

public class WaypointWalker : MonoBehaviour {

    public Transform[] waypoints;
    public bool cyclic;
    public float movementSpeed = 1;

    private int lastWaypointHit = 0;
    private int waypointDirection = 1;

    private Transform CurrentWaypoint
    {
        get { return waypoints[lastWaypointHit]; }
    }

    private Transform TargetWaypoint
    {
        get { 
            return waypoints[FixWaypointIndex(lastWaypointHit + waypointDirection)]; 
        }
    }

    int FixWaypointIndex(int index)
    {
        index = index % waypoints.Length;
        if (index < 0)
        {
            index += waypoints.Length;
        }
        return index;
    }
	// Use this for initialization
	void Start () {
        PrepareMovementForNextWaypoint();

	}

    private void HitWaypoint()
    {
        lastWaypointHit = FixWaypointIndex(lastWaypointHit + waypointDirection);
        PrepareMovementForNextWaypoint();
    }

    private void PrepareMovementForNextWaypoint()
    {
        if (lastWaypointHit == 0) {
            waypointDirection = 1;
        } else if (lastWaypointHit == waypoints.Length - 1 && !cyclic) {
            waypointDirection = -1;
        }
        transform.position = CurrentWaypoint.position;
        transform.LookAt(TargetWaypoint);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, 
            TargetWaypoint.position, Time.deltaTime * movementSpeed);
        //Debug.Log("Distance to target : " + (TargetWaypoint.position - transform.position).magnitude.ToString());
        if ((TargetWaypoint.position - transform.position).magnitude < 0.01f)
        {
            HitWaypoint();
        }
	}
}
