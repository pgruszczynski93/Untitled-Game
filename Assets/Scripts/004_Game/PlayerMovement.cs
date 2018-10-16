using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{

    public class PlayerMovement : MonoBehaviour
    {

        readonly Vector3 right = new Vector3(1, 0, 0);
        readonly Vector3 forward = new Vector3(0, 0, 1);
        readonly Vector3 zero = new Vector3(0, 0, 0);

        float _dt;
        float _currentJoystickDeviation;
        [Range(0, 1)] [SerializeField] float _joystickThreshold;
        [SerializeField] float _baseMoveSpeed;
        [SerializeField] float _currentMoveSpeed;
        [SerializeField] float _runMoveSpeed;
        [SerializeField] float _smoothRotationFactor;

        Vector3 _moveVector;
        Quaternion _forwardRotation;
        Quaternion _smoothedRotation;
        Rigidbody _rb;
        [SerializeField] Animator _animator;
        [SerializeField] Joystick _joystick;

        void Start()
        {
            _runMoveSpeed = 2.0f * _baseMoveSpeed;
            _rb = GetComponent<Rigidbody>();
        }

        void SetMovementAnimator() {

            if (_currentJoystickDeviation > 0.8f)
            {
                _animator.SetBool("IsRunning", true);
                _currentMoveSpeed = _runMoveSpeed;
            }
            else if (_currentJoystickDeviation > _joystickThreshold && _currentJoystickDeviation <= 0.8f)
            {
                _animator.SetBool("IsWalking", true);
                _currentMoveSpeed = _baseMoveSpeed;
            }
            else
            {
                _animator.SetBool("IsRunning", false);
                _animator.SetBool("IsWalking", false);
            }

        }

        void SetAttackAnimator()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("Attack01");
            }
        }

        void MovePlayer()
        {
            _currentJoystickDeviation = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).magnitude;
            SetMovementAnimator();
            SetAttackAnimator();

            if (_currentJoystickDeviation > _joystickThreshold)
            {
                _moveVector = (right * _joystick.Horizontal + forward * _joystick.Vertical).normalized;
                _dt = Time.fixedDeltaTime;

                if (_moveVector != zero)
                {
                    _forwardRotation = Quaternion.LookRotation(_moveVector);
                    _smoothedRotation = Quaternion.Slerp(transform.rotation, _forwardRotation, _smoothRotationFactor * _dt);
                    _rb.MovePosition(transform.position + (_moveVector * _currentMoveSpeed * _dt));
                    _rb.MoveRotation(_forwardRotation);
                }
            }
        }

        void FixedUpdate()
        {
            MovePlayer();
        }
    }

}