using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unit dead state logic.
public class DeadState : BaseState
{
    // Set motion to DeadMove which hides unit under floor.
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

