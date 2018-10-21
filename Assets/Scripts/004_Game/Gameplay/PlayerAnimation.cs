using UnityEngine;

namespace MindworksGames.MyGame
{
    public class PlayerAnimation : HumanoidAnimation
    {

        [HideInInspector] public float walkAnimationThreshold;
        [HideInInspector] public float runAnimationThreshold;

        [SerializeField] PlayerMaster _playerMaster;

        void SetInitRefs()
        {
            walkAnimationThreshold = 0.3f;
            runAnimationThreshold = 0.8f;
            _playerMaster = GetComponent<PlayerMaster>();
        }

        void OnEnable()
        {
            SetInitRefs();
            _playerMaster.OnAnimationsPlaying += SetMovementAnimation;
            _playerMaster.OnAnimationsPlaying += SetAttackAnimation;
            _playerMaster.OnPlayerDie += DisableScript;

        }

        void OnDisable()
        {
            _playerMaster.OnAnimationsPlaying -= SetMovementAnimation;
            _playerMaster.OnAnimationsPlaying -= SetAttackAnimation;
            _playerMaster.OnPlayerDie -= DisableScript;
        }


        protected override void SetAttackAnimation(float inputValue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("Attack01");
            }
        }
        
        protected override void SetMovementAnimation(float joystickValue)
        {
            if (joystickValue > runAnimationThreshold)
            {
                _animator.SetBool("IsRunning", true);
            }
            else if (joystickValue > walkAnimationThreshold && joystickValue <= runAnimationThreshold)
            {
                _animator.SetBool("IsWalking", true);
            }
            else
            {
                _animator.SetBool("IsRunning", false);
                _animator.SetBool("IsWalking", false);
            }
        }
    }
}

