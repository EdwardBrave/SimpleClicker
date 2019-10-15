using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : BaseState
{
    public override void OnClick()
    {
        if (GameManager.instance.mode is GameMode mode)
        {
            if (context.unitType == StateMachine.UnitTypes.Enemy)
                mode.enemyKillCount++;
            else if (context.unitType == StateMachine.UnitTypes.Friendly)
                mode.friendlyKillCount++;
        }
        context.SetState(new DeadState());
    }

    protected override void OnContext()
    {
        base.OnContext();
        var motion = context.GetComponent<Motion>();
        if (motion)
        {
            List<IMoveType> types = motion.types;
            types.Clear();
            types.Add(new ForwardMove());
            types.Add(new DiagonalyMove());
            motion.Start();
        }
    }

    public override void Update()
    {
        
    }
}
