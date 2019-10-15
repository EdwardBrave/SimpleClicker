using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for different map GC realizations for specific Map.
public interface IMapGarbageCollector
{
    void StartCollecting(List<GameObject> objects);

    void Collect(List<GameObject> objects);

    void Stop();
}
