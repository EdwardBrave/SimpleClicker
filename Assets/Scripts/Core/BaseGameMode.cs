using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameMode : MonoBehaviour
{
    public event Action<object, EventArgs> GameOver;

    protected void InvokeGameOver(object e, EventArgs args)
    {
        if (GameOver != null)
            GameOver.Invoke(e, args);
    }

    public abstract void StartRulesCheck();

    public abstract void Stop();

}