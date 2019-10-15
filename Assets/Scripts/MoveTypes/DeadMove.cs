using UnityEngine;

public class DeadMove : IMoveType
{
    //Motion down, under game floor
    public void Move(float speed, Transform transform)
    {
        transform.localPosition += Vector3.down * speed * Time.deltaTime;
    }
}