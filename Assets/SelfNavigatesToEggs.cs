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
[NodeDescription(name: "Self navigates to Eggs", story: "[Self] navigates to [Eggs]", category: "Action", id: "node_self_navigates_to_eggs_01")]
public sealed class SelfNavigatesToEggs01 : BehaviorAction
{
    // Campos renombrados para evitar colisiones con los autogenerados del package
    [SerializeReference] public BlackboardVariable<GameObject> agentVar;
    [SerializeReference] public BlackboardVariable<GameObject> eggTargetVar;

    private NavMeshAgent _nav;

    protected override BehaviorStatus OnStart()
    {
        // Validaciones
        if (agentVar == null || eggTargetVar == null ||
            agentVar.Value == null || eggTargetVar.Value == null)
        {
            return BehaviorStatus.Failure;
        }

        _nav = agentVar.Value.GetComponent<NavMeshAgent>();
        if (_nav == null)
            return BehaviorStatus.Failure;

        _nav.SetDestination(eggTargetVar.Value.transform.position);
        return BehaviorStatus.Running;
    }

    protected override BehaviorStatus OnUpdate()
    {
        if (_nav == null || eggTargetVar == null || eggTargetVar.Value == null)
            return BehaviorStatus.Failure;

        if (_nav.pathPending)
            return BehaviorStatus.Running;

        if (_nav.remainingDistance <= _nav.stoppingDistance + 0.1f)
            return BehaviorStatus.Success;

        return BehaviorStatus.Running;
    }
}
// Fin IA
