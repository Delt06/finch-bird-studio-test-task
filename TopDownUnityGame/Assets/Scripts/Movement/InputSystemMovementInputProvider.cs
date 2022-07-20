using UnityEngine;

namespace Movement
{
    public class InputSystemMovementInputProvider : MonoBehaviour, IMovementInputProvider
    {
        public Vector2 Direction
        {
            get
            {
                var x = Input.GetAxisRaw("Horizontal");
                var y = Input.GetAxisRaw("Vertical");
                var vector = new Vector2(x, y);
                vector = Vector2.ClampMagnitude(vector, 1);
                return vector;
            }
        }
    }
}