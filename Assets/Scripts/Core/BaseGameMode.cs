using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameMode : MonoBehaviour
{
    public event Action<object, GameOverEventArgs> GameOver;

    protected void InvokeGameOver(object sender, GameOverEventArgs e)
    {
        if (GameOver != null)
            GameOver.Invoke(sender, e);
    }

    public abstract void StartRulesCheck();

    public abstract void Stop();

}

public class GameOverEventArgs: EventArgs
{
    public readonly int gameScore;

    public GameOverEventArgs(int gameScore = 0)
    {
        this.gameScore = gameScore;
    }
}