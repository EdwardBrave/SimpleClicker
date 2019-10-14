﻿using UnityEngine;

public class DiagonalyMove : IMoveType
{
    float diagonal = 0.8F;
    private float counter = 2.0F;

    public void Move(float speed, Transform transform)
    {
        counter += Time.deltaTime;
        if (counter > 2.0F && Random.Range(0, 3) == 1)
        {
            counter -= 2.0F;
            diagonal = -diagonal;
        }
        transform.localPosition += new Vector3(diagonal, 0, -0.8F) * speed * Time.deltaTime;
    }
}
