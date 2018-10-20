using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{
    public class PlayerAnimation : HumanoidAnimation
    {

        public delegate void PlayerAnimationsEventHandler(float inputValue);
        public event PlayerAnimationsEventHandler OnAnimationsPlaying;

        [HideInInspector] public float walkAnimationThreshold;
        [HideInInspector] public float runAnimationThreshold;

        void SetInitRefs()
        {
            walkAnimationThreshold = 0.3f;
            runAnimationThreshold = 0.8f;
        }

        void OnEnable()
        {
            OnAnimationsPlaying += SetMovementAnimation;
            OnAnimationsPlaying += SetAttackAnimation;
        }

        void OnDisable()
        {
            OnAnimationsPlaying -= SetMovementAnimation;
            OnAnimationsPlaying -= SetAttackAnimation;
        }

        void Start()
        {
            SetInitRefs();
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

        public void CallOnAnimationsPlaying(float inputVal)
        {
            OnAnimationsPlaying?.Invoke(inputVal);
        }

    }
}

