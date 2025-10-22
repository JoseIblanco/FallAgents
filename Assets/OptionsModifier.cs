using System;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Options", story: "Switch", category: "Flow/Abort", id: "9c1efd0742b3a01f19222162087d7242")]
public partial class OptionsModifier : Modifier
{

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
        if ()
    }

    protected override void OnEnd()
    {
    }
}

