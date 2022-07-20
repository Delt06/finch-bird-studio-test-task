using UnityEngine;

namespace Animations
{
    public class MovementSpriteFlip : MonoBehaviour
    {
        [SerializeField] private Movement.Movement _movement;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void LateUpdate()
        {
            var lastDirectionX = _movement.LastDirection.x;
            if (Mathf.Approximately(lastDirectionX, 0)) return;

            _spriteRenderer.flipX = lastDirectionX < 0f;
        }
    }
}