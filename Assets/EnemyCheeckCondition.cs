using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Enemy cheeck", story: "[Agent] cheecks for [EnemyAgents]", category: "Conditions", id: "8733b2c3fa7db4b4392f770d6ce33702")]
public partial class EnemyCheeckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> EnemyAgents;

    public override bool IsTrue()
    {
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
