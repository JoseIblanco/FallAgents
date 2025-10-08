using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class FallAgent : MonoBehaviour
{
    public NavMeshAgent agent;

    private List<Transform> routePoints = new List<Transform>();
    private int currentPoint = 0;

    // -- velocidad
    private float baseSpeed;
    private float currentMultiplier = 1f;

    void Awake()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        baseSpeed = agent.speed;
        ApplySpeed();

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("WayPoint");
        //Start IA
        System.Random rnd = new System.Random();
        for (int i = objectsWithTag.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (objectsWithTag[i], objectsWithTag[j]) = (objectsWithTag[j], objectsWithTag[i]);
        }

        int count = Mathf.Min(5, objectsWithTag.Length);
        for (int i = 0; i < count; i++)
            routePoints.Add(objectsWithTag[i].transform);

        if (routePoints.Count > 0)
            agent.SetDestination(routePoints[0].position);
        //End IA
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPoint = (currentPoint + 1) % routePoints.Count;
            agent.SetDestination(routePoints[currentPoint].position);
        }
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        currentMultiplier = multiplier;
        ApplySpeed();
    }

    private void ApplySpeed()
    {
        agent.speed = baseSpeed * currentMultiplier;
    }
}

