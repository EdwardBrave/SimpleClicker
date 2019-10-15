using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Realizes a flexible switching and executing between different states (behaviours)
public class StateMachine : MonoBehaviour, IPointerClickHandler
{
    private BaseState state;
    public UnitTypes unitType;

    public enum UnitTypes
    {
        Enemy = -1,
        Neutral = 0,
        Friendly = 1
    };

    public void SetState(BaseState newState)
    {
        state = newState;
        state.SetContext(this);
    }

    public Type GetStateType()
    {
        if (state != null)
            return state.GetType();
        return null;
    }

    void Start()
    {
        if (state == null)
            SetState(new RunState());
    }

    void Update()
    {
        state.Update();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        state.OnClick();
    }
}
