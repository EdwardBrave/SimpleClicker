using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour, IStrategy
{
    public void action()
    {
        Debug.Log("Hello my first strategy");
    }
}
