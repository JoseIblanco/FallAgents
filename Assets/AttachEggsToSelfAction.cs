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
    name: "Self navigates to Eggs",
    story: "Self navigates to Eggs",
    category: "Action"
)]
public partial class SelfNavigatesToEggs : BehaviorAction
{
    [SerializeReference] public BlackboardVariable<GameObject> agent;
    [SerializeReference] public BlackboardVariable<GameObject> eggTarget;

    private NavMeshAgent nav;

    protected override BehaviorStatus OnStart()
    {
        if (agent?.Value == null || eggTarget?.Value == null)
            return BehaviorStatus.Failure;

        nav = agent.Value.GetComponent<NavMeshAgent>();
        if (nav == null)
            return BehaviorStatus.Failure;

        nav.SetDestination(eggTarget.Value.transform.position);
        return BehaviorStatus.Running;
    }

    protected override BehaviorStatus OnUpdate()
    {
        if (nav == null || eggTarget?.Value == null)
            return BehaviorStatus.Failure;

        if (nav.pathPending)
            return BehaviorStatus.Running;

        if (nav.remainingDistance <= nav.stoppingDistance + 0.1f)
            return BehaviorStatus.Success;

        return BehaviorStatus.Running;
    }
}
// Fin IA
