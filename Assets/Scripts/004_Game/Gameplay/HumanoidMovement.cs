using UnityEngine;

namespace MindworksGames.MyGame
{
    public abstract class HumanoidMovement : MonoBehaviour
    {
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

        protected virtual void MoveHumanoid() { }

        protected virtual void SetInitRefs()
        {
            _runMoveSpeed = _runMultiplerValue * _baseMoveSpeed;
            _rb = GetComponent<Rigidbody>();
        }
    }
}

