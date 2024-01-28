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

    void GetWaypoints()
    {
        if (waypointsContainer != null)
        {
            // Получаем все точки из контейнера
            waypoints = new Transform[waypointsContainer.childCount];
            for (int i = 0; i < waypointsContainer.childCount; i++)
            {
                waypoints[i] = waypointsContainer.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("Укажите контейнер с точками (waypointsContainer) в инспекторе!");
        }
    }

    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            yield return StartCoroutine(MoveTo(waypoints[currentWaypointIndex].position));

            // Переходим к следующей точке
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    IEnumerator MoveTo(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            // Поворот к целевой точке
            transform.LookAt(destination);

            // Перемещение к целевой точке
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            yield return null;
        }
    }
    //public Transform pointA;
    //public Transform pointB;
    //public float speed = 2f;

    //private void Start()
    //{
    //    StartCoroutine(MoveBetweenPoints());
    //}

    //IEnumerator MoveBetweenPoints()
    //{
    //    while (true)
    //    {
    //        yield return StartCoroutine(MoveTo(pointA.position));
    //        yield return StartCoroutine(MoveTo(pointB.position));
    //    }
    //}

    //IEnumerator MoveTo(Vector3 destination)
    //{
    //    while (Vector3.Distance(transform.position, destination) > 0.1f)
    //    {
    //        transform.LookAt(destination);
    //        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    //        yield return null;
    //    }
    //}
}