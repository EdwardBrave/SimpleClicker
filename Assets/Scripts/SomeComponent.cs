using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeComponent : MonoBehaviour
{
    public MonoBehaviour strategy;

    // Start is called before the first frame update
    void Start()
    {
        (strategy as IStrategy).action();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
