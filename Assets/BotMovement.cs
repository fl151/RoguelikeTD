using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Transform waypointsContainer;
    public float speed = 2f;

    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        GetWaypoints();
        StartCoroutine(MoveBetweenPoints());
    }

    private void GetWaypoints()
    {
        if (waypointsContainer != null)
        {
            waypoints = new Transform[waypointsContainer.childCount];
            for (int i = 0; i < waypointsContainer.childCount; i++)
            {
                waypoints[i] = waypointsContainer.GetChild(i);
            }
        }
    }

    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {            
            ShuffleWaypoints();

            for (int i = 0; i < waypoints.Length; i++)
            {
                yield return StartCoroutine(MoveTo(waypoints[i].position));
            }
        }
    }

    void ShuffleWaypoints()
    {
        for (int i = waypoints.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = waypoints[i];
            waypoints[i] = waypoints[randomIndex];
            waypoints[randomIndex] = temp;
        }
    }

    IEnumerator MoveTo(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.LookAt(destination);
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            yield return null;
        }
    }    
}