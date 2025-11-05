// Inicio IA
using System;
using UnityEngine;
using Unity.Behavior;
using Unity.Properties;

// Alias para evitar conflicto con System.Action
using BehaviorAction = Unity.Behavior.Action;
using BehaviorStatus = Unity.Behavior.Action.Status;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Soltar", story: "[Agent] Drops [Egg]", category: "Action", id: "5d22ef9b93da753e47acd21e146d904b")]
public sealed class DropEggAction : BehaviorAction
{
    [SerializeReference] public BlackboardVariable<GameObject> agentVar;
    [SerializeReference] public BlackboardVariable<GameObject> eggTargetVar;
    [SerializeReference] public BlackboardVariable<bool> hasEggVar;       // opcional
    [SerializeReference] public BlackboardVariable<bool> eggDetectedVar;  // opcional

    protected override BehaviorStatus OnStart() => BehaviorStatus.Running;

    protected override BehaviorStatus OnUpdate()
    {
        if (agentVar == null || agentVar.Value == null)
            return BehaviorStatus.Failure;

        Transform eggTransform = null;

        // Si hay referencia directa, úsala; si no, intenta buscarlo como hijo del agente
        if (eggTargetVar != null && eggTargetVar.Value != null)
            eggTransform = eggTargetVar.Value.transform;
        else if (agentVar.Value.transform.childCount > 0)
            eggTransform = agentVar.Value.transform.GetChild(0);

        if (eggTransform == null)
            return BehaviorStatus.Failure;

        // Desvincular huevo del agente
        eggTransform.SetParent(null);

        // Físicas: activar y poner velocidades a cero (API nueva y antigua)
        var rb = eggTransform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;

#if UNITY_6000_0_OR_NEWER
            rb.linearVelocity = Vector3.zero;
#else
            rb.velocity = Vector3.zero;
#endif
            rb.angularVelocity = Vector3.zero;
        }

        // Limpiar Blackboard
        if (hasEggVar != null) hasEggVar.Value = false;
        if (eggDetectedVar != null) eggDetectedVar.Value = false;
        if (eggTargetVar != null) eggTargetVar.Value = null;

        return BehaviorStatus.Success;
    }

    protected override void OnEnd() { }
}
// Fin IA
