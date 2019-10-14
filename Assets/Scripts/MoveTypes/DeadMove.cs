using UnityEngine;

public class DeadMove : IMoveType
{
    public void Move(float speed, Transform transform)
    {
        transform.localPosition += Vector3.down * speed * Time.deltaTime;
    }
}