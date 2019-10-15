using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapGarbageCollector
{
    void StartCollecting(List<GameObject> objects);

    void Collect(List<GameObject> objects);

    void Stop();
}
