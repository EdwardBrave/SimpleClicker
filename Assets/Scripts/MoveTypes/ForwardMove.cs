using UnityEngine;

public class ForwardMove : IMoveType
{
    //Motion forward (closer to player)
    public void Move(float speed, Transform transform)
    {
        transform.localPosition += Vector3.back * speed * Time.deltaTime;
    }
}
