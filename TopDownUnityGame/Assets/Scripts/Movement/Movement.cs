using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(IMovementInputProvider))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] [Min(0f)] private float _speed = 1f;

        private IMovementInputProvider _inputProvider;

        public Vector2 LastDirection { get; private set; }

        private void Start()
        {
            _inputProvider = GetComponent<IMovementInputProvider>();
        }

        private void FixedUpdate()
        {
            var direction = _inputProvider.Direction;
            var velocity = direction * _speed;
            _rigidbody.velocity = velocity;
            LastDirection = direction;
        }
    }
}