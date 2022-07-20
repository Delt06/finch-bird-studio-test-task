using UnityEngine;

namespace Movement
{
    public interface IMovementInputProvider
    {
        Vector2 Direction { get; }
    }
}