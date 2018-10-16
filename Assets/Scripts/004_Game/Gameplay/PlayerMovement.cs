using UnityEngine;

namespace MindworksGames.MyGame
{
    public class PlayerMovement : HumanoidMovement
    {

        float _currentJoystickDeviation;
        [Range(0, 1)] [SerializeField] float _joystickThreshold;

        [SerializeField] Joystick _joystick;

        protected override void Start()
        {
            base.Start();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void SetMovementAnimator() {

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

        protected override void SetAttackAnimator()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("Attack01");
            }
        }

        protected override void MoveHumanoid()
        {
            _currentJoystickDeviation = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).magnitude;

            OnAnimationInvoked?.Invoke();

            if (_currentJoystickDeviation > _joystickThreshold)
            {
                _moveVector = (MathHelper.rightVec * _joystick.Horizontal + MathHelper.forwardVec * _joystick.Vertical).normalized;
                _dt = Time.fixedDeltaTime;

                if (_moveVector != MathHelper.zeroVec)
                {
                    _forwardRotation = Quaternion.LookRotation(_moveVector);
                    _smoothedRotation = Quaternion.Slerp(transform.rotation, _forwardRotation, _smoothRotationFactor * _dt);
                    _rb.MovePosition(transform.position + (_moveVector * _currentMoveSpeed * _dt));
                    _rb.MoveRotation(_forwardRotation);
                }
            }
        }

        protected override void FixedUpdate()
        {
            MoveHumanoid();
        }
    }

}