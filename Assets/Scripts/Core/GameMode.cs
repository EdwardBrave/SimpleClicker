using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specific set of game rules. Control game process, count events,
// check rules and game end conditions. 
public class GameMode : BaseGameMode
{
    public GameObject floor;

    public bool isActive = false;

    public int outLimit;
    public int friendlyKillLimit;

    [ReadOnly]
    public int outCount;

    [ReadOnly]
    public int friendlyKillCount;

    [ReadOnly]
    public int enemyKillCount;

    private Vector3[] edgeCoords = new Vector3[2];
    private List<GameObject> units;

    void Start()
    {
        units = GameManager.instance.map.GetUnits();
        Vector3 floorPosition = floor.transform.position;
        Vector3 floorScale = floor.transform.localScale * 5;
        edgeCoords[0] = new Vector3(floorPosition.x - floorScale.x, floorPosition.y, floorPosition.z - floorScale.z);
        edgeCoords[1] = new Vector3(floorPosition.x + floorScale.x, floorPosition.y, floorPosition.z + floorScale.z);
    }

    public override void StartRulesCheck()
    {
        isActive = true;
        outCount = 0;
        friendlyKillCount = 0;
        enemyKillCount = 0;
    }

    private void Update()
    {
        if (!isActive)
            return;
        
        if (friendlyKillCount > friendlyKillLimit)
        {
            InvokeGameOver(this, new GameOverEventArgs(enemyKillCount));
            Stop();
            return;
        }

        foreach(var unit in units)
        {
            Vector3 unitPosition = unit.transform.position;
            
            var state = unit.GetComponent<StateMachine>();
            if (!state || state.GetStateType() != typeof(RunState) || unitPosition.y + 0.5F < edgeCoords[0].y)
                continue;
            else if (!IsInFloorZone(unitPosition))
            {
                state.SetState(new DeadState());
                if (state.unitType == StateMachine.UnitTypes.Enemy)
                    outCount++;
                if (outCount > outLimit)
                {
                    InvokeGameOver(this, new GameOverEventArgs(enemyKillCount));
                    Stop();
                    break;
                }

            }
        }
    }

    private bool IsInFloorZone(Vector3 pos)
    {
        return (edgeCoords[0].x < pos.x + 0.5F && pos.x - 0.5F < edgeCoords[1].x &&
                edgeCoords[0].z < pos.z + 0.5F && pos.z - 0.5F < edgeCoords[1].z);
    }

    public override void Stop()
    {
        foreach(var unit in units)
        {
            var state = unit.GetComponent<StateMachine>();
            if (state || state.GetStateType() != typeof(DeadState))
                state.SetState(new DeadState());
        }
        isActive = false;
    }


}
