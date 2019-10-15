using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unit run state logic
public class RunState : BaseState
{
    // "Killing" self on mouse click and update game counters
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

    public override void Update()
    {
        
    }
}
