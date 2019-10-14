using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed = 1.0F;
    public List<IMoveType> types = new List<IMoveType>();
    public float changeChance = 0.5F;

    private IMoveType selected;
    private float counter = 0;

    private void Awake()
    {
        types.Add(new ForwardMove());
        types.Add(new DiagonalyMove());
        types.Add(new DeadMove());
    }

    private void Start()
    {
        if (types.Count > 0)
            selected = types[0];
    }

    private void Update()
    {
        if (types.Count <= 0)
            return;
        counter += Time.deltaTime;
        if (counter > 2.0F && changeChance > Random.Range(0.0F, 1.0F))
        {
            selected = types[Random.Range(0, types.Count)];
            counter -= 2.0F;
        }
        selected.Move(speed, transform);
    }
}
