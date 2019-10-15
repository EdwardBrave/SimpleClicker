using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapManager
{
    List<GameObject> GetUnits();

    void StartGeneration();

    void Pause();

    void Clear();
}
