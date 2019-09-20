using UnityEngine;

public interface IMovable
{
    void Movement(float horizontal, float vertical);

    void Rotation(float horizontal, float vertical, Vector3 targetDirection);
}
