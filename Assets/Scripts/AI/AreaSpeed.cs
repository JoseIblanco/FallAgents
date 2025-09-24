using UnityEngine;
using UnityEngine.AI;

public class AreaSpeed : MonoBehaviour
{
    private NavMeshAgent agent;

    public float defaultSpeed = 3.5f;
    public float TreadmillSpeed = 5.25f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        UpdateAgentSpeedBasedOnArea();
    }

    void UpdateAgentSpeedBasedOnArea()
    {
        //El profesor ha dicho en clase que no uemos Mask...
        NavMeshHit hit;

        if (NavMesh.SamplePosition(agent.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            int areaMask = hit.mask;


            if (areaMask == (1 << NavMesh.GetAreaFromName("Treadmill")))
            {
                agent.speed = TreadmillSpeed;
            }
            else
            {
                agent.speed = defaultSpeed;
            }
        }
    }
}
