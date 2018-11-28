using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[waypointIndex];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            waypointIndex = -1;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
