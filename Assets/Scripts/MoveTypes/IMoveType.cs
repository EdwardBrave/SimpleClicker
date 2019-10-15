using UnityEngine;

//Interface for different Motion algorithm realizations
public interface IMoveType
{
    void Move(float speed, Transform transform);
}
