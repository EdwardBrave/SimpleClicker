using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateMachine : MonoBehaviour, IPointerClickHandler
{
    public bool clickable;
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
        return state.GetType();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetState(new RunState());
    }

    // Update is called once per frame
    void Update()
    {
        state.Update();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        state.OnClick();
    }
}
