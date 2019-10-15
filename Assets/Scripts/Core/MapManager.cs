using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour, IMapManager
{
    public List<GameObject> units;


    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public List<GameObject> GetUnits()
    {
        return units;
    }

    public void Pause()
    {
        throw new System.NotImplementedException();
    }

    public void StartGeneration()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
