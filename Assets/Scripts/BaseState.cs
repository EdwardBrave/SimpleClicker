using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected StateMachine context;

    public void SetContext(StateMachine context)
    {
        this.context = context;
        OnContext();
    }

    protected virtual void OnContext()
    {

    }

    public abstract void Update();

    public abstract void OnClick();
}
