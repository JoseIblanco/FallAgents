using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AreaSpeed : MonoBehaviour
{
    NavMeshAgent agent;
    NavMeshModifierVolume volume;
    float baseSpeed;

    void Awake()
    {
        volume = GetComponent<NavMeshModifierVolume>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent")) 
        {
            agent = other.GetComponent<NavMeshAgent>();
            if (agent != null && volume != null)
            {
                baseSpeed = agent.speed; 
                agent.speed /= 0.5f; 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            if (agent != null && volume != null)
            {
                agent.speed = baseSpeed; 
                agent = null; 
            }
        }
    }
}