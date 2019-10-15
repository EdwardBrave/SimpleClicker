using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstraction for creation different game modes with specific rules checking algorithms.
public abstract class BaseGameMode : MonoBehaviour
{
    // Invokes when game ended (some endGame rules worked).
    public event Action<object, GameOverEventArgs> GameOver;

    // Access to Invoke event from children.
    protected void InvokeGameOver(object sender, GameOverEventArgs e)
    {
        if (GameOver != null)
            GameOver.Invoke(sender, e);
    }

    public abstract void StartRulesCheck();

    public abstract void Stop();

}

// Events args which allows to send the game score.
public class GameOverEventArgs: EventArgs
{
    public readonly int gameScore;

    public GameOverEventArgs(int gameScore = 0)
    {
        this.gameScore = gameScore;
    }
}