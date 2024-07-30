using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private GameObject[] targets; // Array of targets

    private int currentTargetIndex;

    private bool isWaiting = false;

    private float waitTime;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        // Check if the agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (!isWaiting)
            {
                StartWaiting();
            }
            else
            {
                UpdateWaiting();
            }
        }
    }

    void StartWaiting()
    {
        isWaiting = true;
        waitTime = Random.Range(1f, 3f);
        waitTimer = 0f;
        agent.isStopped = true;
    }

    void UpdateWaiting()
    {
        waitTimer += Time.deltaTime;
        if (waitTimer >= waitTime)
        {
            isWaiting = false;
            agent.isStopped = false;
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        // Select a random target from the array
        currentTargetIndex = Random.Range(0, targets.Length);
        agent.destination = targets[currentTargetIndex].transform.position;
    }
}
