using UnityEngine;

namespace MindworksGames.MyGame
{
    public class PlayerMovement : HumanoidMovement
    {

        float _currentJoystickDeviation;
        [Range(0, 1)] [SerializeField] float _joystickThreshold;

        [SerializeField] Joystick _joystick;
        [SerializeField] PlayerMaster _playerMaster;


        protected override void SetInitRefs()
        {
            base.SetInitRefs();
            _playerMaster = GetComponent<PlayerMaster>();
        }

        void OnEnable()
        {
            SetInitRefs();

            _playerMaster.OnPlayerMoving += MoveHumanoid;
        }

        void OnDisable()
        {
            _playerMaster.OnPlayerMoving -= MoveHumanoid;
        }

        protected override void MoveHumanoid()
        {
            _currentJoystickDeviation = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).sqrMagnitude;

            _playerMaster.CallOnAnimationsPlaying(_currentJoystickDeviation);

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
    }

}