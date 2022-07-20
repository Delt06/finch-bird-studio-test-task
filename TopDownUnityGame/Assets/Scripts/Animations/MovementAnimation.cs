using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(SpriteAnimator))]
    public class MovementAnimation : MonoBehaviour
    {
        private static readonly int IdleId = Animator.StringToHash("Idle");
        private static readonly int WalkId = Animator.StringToHash("Walk");

        [SerializeField] private Movement.Movement _movement;
        [SerializeField] [Min(0f)] private float _movementThreshold = 0.1f;

        private SpriteAnimator _spriteAnimator;

        private void Start()
        {
            _spriteAnimator = GetComponent<SpriteAnimator>();
        }

        private void Update()
        {
            var isMoving = _movement.LastDirection.sqrMagnitude >= _movementThreshold * _movementThreshold;
            var animationId = isMoving ? WalkId : IdleId;
            _spriteAnimator.Play(animationId);
        }
    }
}