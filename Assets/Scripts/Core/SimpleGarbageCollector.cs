using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collect and remove out of camera view objects and disables units for optimization.
public class SimpleGarbageCollector : MonoBehaviour, IMapGarbageCollector
{
    public float update;
    public Transform floor;

    private float updateCounter;
    private List<GameObject> objects;
    private bool isActive = false;

    public void StartCollecting(List<GameObject> objects)
    {
        this.objects = objects;
        isActive = true;
        updateCounter = update;
    }

    void Update()
    {
        if (!isActive)
            return;
        updateCounter += Time.deltaTime;
        if (updateCounter >= update)
        {
            updateCounter -= update;
            Collect(objects);
        } 
    }

    public void Collect(List<GameObject> objects)
    {
        float yPos = floor.position.y;
        for (int i = objects.Count-1; i >= 0; --i)
        {
            var obj = objects[i];
            if (obj.transform.position.y + 0.5F < yPos)
            {
                objects.Remove(obj);
                Destroy(obj.gameObject);
            }
        }
    }

    public void Stop()
    {
        isActive = false;
    }
   
}
