using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
    protected override void OnContext()
    {
        var motion = context.GetComponent<Motion>();
        if (motion)
        {
            List<IMoveType> types = motion.types;
            types.Clear();
            types.Add(new DeadMove());
            motion.Start();
        }
    }

    public override void OnClick()
    {

    }

    public override void Update()
    {

    }
}

