using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    // Start is called before the first frame update
    void Start()
    {
        if (state == null)
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
