// Inicio IA
using System;
using UnityEngine;
using UnityEngine.AI;
using Unity.Behavior;
using Unity.Properties;

// Alias para evitar conflicto con System.Action
using BehaviorAction = Unity.Behavior.Action;
using BehaviorStatus = Unity.Behavior.Action.Status;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Self sees Egg",
    story: "Self Sees Egg",
    category: "Action",
    id: "See_action_01"
)]
public partial class SelfSeesEgg : BehaviorAction
{
    [SerializeReference] public BlackboardVariable<GameObject> agent;
    [SerializeReference] public BlackboardVariable<float> rayDistance;
    [SerializeReference] public BlackboardVariable<bool> eggDetected;
    [SerializeReference] public BlackboardVariable<GameObject> eggTarget;

    private Vector3 lastDir = Vector3.forward;

    protected override BehaviorStatus OnStart()
    {
        eggDetected.Value = false;
        return BehaviorStatus.Running;
    }

    protected override BehaviorStatus OnUpdate()
    {
        if (agent?.Value == null) return BehaviorStatus.Failure;

        NavMeshAgent nav = agent.Value.GetComponent<NavMeshAgent>();

        // Dirección hacia delante (usa velocidad si se mueve)
        if (nav != null && nav.velocity.sqrMagnitude > 0.01f)
            lastDir = nav.velocity.normalized;
        else
            lastDir = agent.Value.transform.forward;

        Vector3 origin = agent.Value.transform.position + Vector3.up * 1f;

        // Lanza el Raycast
        if (Physics.Raycast(origin, lastDir, out RaycastHit hit, rayDistance.Value))
        {
            Debug.DrawRay(origin, lastDir * hit.distance, Color.red);

            if (hit.collider.CompareTag("Egg"))
            {
                eggDetected.Value = true;
                eggTarget.Value = hit.collider.gameObject;
                return BehaviorStatus.Success;
            }
        }
        else
        {
            Debug.DrawRay(origin, lastDir * rayDistance.Value, Color.green);
        }

        eggDetected.Value = false;
        return BehaviorStatus.Running;
    }
}
// Fin IA
