using JetBrains.Annotations;
using UnityEngine;

namespace Animations
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [CanBeNull]
        private int? _lastState;

        public void Play(int state)
        {
            if (_lastState == state) return;

            _animator.Play(state);
            _lastState = state;
        }
    }
}