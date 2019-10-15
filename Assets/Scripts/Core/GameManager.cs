using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public IMapManager map;

    public BaseGameMode mode;

    public GameObject userInterface;


    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            map = GetComponent<IMapManager>();
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
