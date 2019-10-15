using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for different Map Managers (generators) creation 
// and connection to GameManager.
public interface IMapManager
{
    List<GameObject> GetUnits();

    void StartGeneration();

    void Pause();

    void Clear();
}
