using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{
    public abstract class HumanoidMovement : MonoBehaviour
    {
        protected System.Action OnAnimationInvoked = delegate { };

        protected float _dt;
        [SerializeField] protected float _baseMoveSpeed;
        [SerializeField] protected float _currentMoveSpeed;
        [SerializeField] protected float _runMoveSpeed;
        [SerializeField] protected float _smoothRotationFactor;
        [SerializeField] protected float _runMultiplerValue;


        protected Vector3 _moveVector;
        protected Quaternion _forwardRotation;
        protected Quaternion _smoothedRotation;
        [SerializeField] protected Rigidbody _rb;
        [SerializeField] protected Animator _animator;
        

        protected abstract void SetMovementAnimator();
        protected abstract void SetAttackAnimator();

        protected virtual void OnEnable()
        {
            OnAnimationInvoked += SetMovementAnimator;
            OnAnimationInvoked += SetAttackAnimator;
        }

        protected virtual void OnDisable()
        {
            OnAnimationInvoked -= SetMovementAnimator;
            OnAnimationInvoked -= SetAttackAnimator;
        }

        protected virtual void Start()
        {
            _runMoveSpeed = _runMultiplerValue * _baseMoveSpeed;
            _rb = GetComponent<Rigidbody>();
        }

        protected virtual void FixedUpdate() { }
        protected virtual void OnTriggerEnter() { }
        protected virtual void OnTriggerStay() { }
        protected virtual void OnTriggerExit() { }

        protected virtual void MoveHumanoid() { }
        

    }
}

