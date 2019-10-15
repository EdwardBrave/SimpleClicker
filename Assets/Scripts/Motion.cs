using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed = 1.0F;
    public List<IMoveType> types = new List<IMoveType>();
    private float changeTime = 0.5F;

    private IMoveType selected;
    private float counter = 0;

    public void Start()
    {
        if (types.Count > 0)
            selected = types[0];
        changeTime = 0;
    }

    private void Update()
    {
        if (types.Count <= 0)
            return;
        counter += Time.deltaTime;
        if (counter > changeTime)
        {
            selected = types[Random.Range(0, types.Count)];
            counter -= changeTime;
            changeTime = Random.Range(0.0F, 4.0F);
        }
        selected.Move(speed, transform);
    }
}
