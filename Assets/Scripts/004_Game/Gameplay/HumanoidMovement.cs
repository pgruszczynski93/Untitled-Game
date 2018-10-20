using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{
    public class HumanoidMovement : MonoBehaviour
    {
        public delegate void HumanoidEventHandler();

        protected float _dt;
        [SerializeField] protected float _baseMoveSpeed;
        [SerializeField] protected float _currentMoveSpeed;
        [SerializeField] protected float _runMoveSpeed;
        [SerializeField] protected float _smoothRotationFactor;
        [SerializeField] protected float _runMultiplerValue;

        protected Vector3 _moveVector;
        protected Vector3 _currentTargetPos;
        protected Quaternion _forwardRotation;
        protected Quaternion _smoothedRotation;
        [SerializeField] protected Transform _currentTarget;
        [SerializeField] protected Rigidbody _rb;
        

        protected virtual void Start()
        {
            SetInitRefs();
        }

        protected virtual void FixedUpdate() { }
        protected virtual void OnTriggerEnter(Collider col) { }
        protected virtual void OnTriggerStay(Collider col) { }
        protected virtual void OnTriggerExit(Collider col) { }

        protected virtual void MoveHumanoid() { }


        void SetInitRefs()
        {
            _runMoveSpeed = _runMultiplerValue * _baseMoveSpeed;
            _rb = GetComponent<Rigidbody>();
        }
    }
}

