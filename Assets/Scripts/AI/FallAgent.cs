using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class FallAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    private List<Transform> routePoints = new List<Transform>();

    void Start()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("WayPoint");

        // IA Start
        System.Random rnd = new System.Random();
        for (int i = objectsWithTag.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            GameObject temp = objectsWithTag[i];
            objectsWithTag[i] = objectsWithTag[j];
            objectsWithTag[j] = temp;
        }

        int count = Mathf.Min(5, objectsWithTag.Length);
        for (int i = 0; i < count; i++)
        {
            routePoints.Add(objectsWithTag[i].transform);
        }

        if (routePoints.Count > 0)
        {
            agent.SetDestination(routePoints[0].position);
        }
    }

    int currentPoint = 0;

    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPoint++;
            if (currentPoint < routePoints.Count)
            {
                agent.SetDestination(routePoints[currentPoint].position);
            }
            else
            {
                currentPoint = 0;
                agent.SetDestination(routePoints[currentPoint].position);
            }
        }
    }
}
