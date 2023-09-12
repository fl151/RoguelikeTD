using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent myAgent;


    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MoveMage player = FindObjectOfType<MoveMage>();

        if (player != null)
        {
            myAgent.destination = player.transform.position;
        }
    }
}