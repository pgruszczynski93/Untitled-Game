using UnityEngine;

namespace MindworksGames.MyGame
{
    public class PlayerMovement : HumanoidMovement
    {
        public event HumanoidEventHandler OnPlayerMoving;
        public event HumanoidEventHandler OnPlayerLevelUp;
        public event HumanoidEventHandler OnPlayerAttack;
        public event HumanoidEventHandler OnPlayerDie;

        float _currentJoystickDeviation;
        [Range(0, 1)] [SerializeField] float _joystickThreshold;

        [SerializeField] Joystick _joystick;
        [SerializeField] PlayerAnimation _animationController;        

        protected override void Start()
        {
            base.Start();

            _animationController = GetComponent<PlayerAnimation>();
            _animationController.walkAnimationThreshold = _joystickThreshold; 
        }

        void OnEnable()
        {
            OnPlayerMoving += MoveHumanoid;
        }

        void OnDisable()
        {
            OnPlayerMoving -= MoveHumanoid;
        }


        protected override void MoveHumanoid()
        {
            _currentJoystickDeviation = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).sqrMagnitude;

            _animationController.CallOnAnimationsPlaying(_currentJoystickDeviation);

            if (_currentJoystickDeviation > _joystickThreshold)
            {
                _moveVector = (MathHelper.rightVec * _joystick.Horizontal + MathHelper.forwardVec * _joystick.Vertical).normalized;
                _dt = Time.fixedDeltaTime;
                _currentMoveSpeed = (_currentJoystickDeviation > 0.8f) ? 
                                    _runMoveSpeed : ((_currentJoystickDeviation > _joystickThreshold && _currentJoystickDeviation <= 0.8f) ? 
                                    _baseMoveSpeed : 0f);

                if (_moveVector != MathHelper.zeroVec)
                {
                    _forwardRotation = Quaternion.LookRotation(_moveVector);
                    _smoothedRotation = Quaternion.Slerp(transform.rotation, _forwardRotation, _smoothRotationFactor * _dt);
                    _rb.MovePosition(transform.position + (_moveVector * _currentMoveSpeed * _dt));
                    _rb.MoveRotation(_forwardRotation);
                }
            }
        }

        public void CallOnPlayerMovementStarted()
        {
            OnPlayerMoving?.Invoke();
        }

        public void CallOnPlayerLevelUp()
        {
            OnPlayerLevelUp?.Invoke();
        }

        public void CallOnPlayerAttack()
        {
            OnPlayerAttack?.Invoke();
        }

        public void CallOnPlayerDie()
        {
            OnPlayerDie?.Invoke();
        }

        protected override void FixedUpdate()
        {
            CallOnPlayerMovementStarted();
        }
    }

}