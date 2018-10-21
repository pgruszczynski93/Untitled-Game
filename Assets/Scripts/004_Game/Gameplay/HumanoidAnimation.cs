using UnityEngine;

namespace MindworksGames.MyGame
{
    public abstract class HumanoidAnimation : MonoBehaviour
    {

        [SerializeField] protected Animator _animator;

        protected virtual void SetMovementAnimation() { }
        protected virtual void SetMovementAnimation(float joystickValue) { }
        protected virtual void SetAttackAnimation() { }
        protected virtual void SetAttackAnimation(float joystickValue) { }

        protected void DisableScript()
        {
            if (_animator != null)
            {
                _animator.enabled = false;
            }
            enabled = false;
        }
    }

}
