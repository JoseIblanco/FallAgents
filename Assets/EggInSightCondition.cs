using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "EggInSight", story: "Agent cheeks for Eggs", category: "Conditions", id: "60cdf954bbb257ff1c5152a7245f7f6e")]
public partial class EggInSightCondition : Condition
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
