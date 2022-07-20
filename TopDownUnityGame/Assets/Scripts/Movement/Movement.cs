using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(IMovementInputProvider))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] [Min(0f)] private float _speed = 1f;

        private IMovementInputProvider _inputProvider;

        private void Start()
        {
            _inputProvider = GetComponent<IMovementInputProvider>();
        }

        private void FixedUpdate()
        {
            var velocity = _inputProvider.Direction * _speed;
            _rigidbody.velocity = velocity;
        }
    }
}