using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Hitt", story: "Enemy attack", category: "Conditions", id: "d2030c330eee41365b6eb73d3fad27d7")]
public partial class HittCondition : Condition
{

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
