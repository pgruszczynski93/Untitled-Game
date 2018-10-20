using UnityEngine;

namespace MindworksGames.MyGame
{
    public class CameraController : MonoBehaviour
    {
        public delegate void MainCameraEventHandler();
        public event MainCameraEventHandler OnCameraTracking;

        float _dt;
        [SerializeField] float _smoothFactor;

        Vector3 _offset;
        Vector3 _targetPosition;
        Vector3 _smoothedPosition;
        [SerializeField] Transform _target;

        void SetInitRefs()
        {
            _offset = _target.position - transform.position;
        }

        void OnEnable()
        {
            SetInitRefs();
            OnCameraTracking += MoveCamera;
        }

        void OnDisable()
        {
            OnCameraTracking -= MoveCamera;
        }

        void CallOnCameraTracking()
        {
            OnCameraTracking?.Invoke();
        }

        void FixedUpdate()
        {
            CallOnCameraTracking();
        }

        void MoveCamera()
        {
            _dt = Time.fixedDeltaTime;
            _targetPosition = _target.position - _offset;
            _smoothedPosition = Vector3.Lerp(transform.position, _targetPosition, _smoothFactor * _dt);
            transform.position = _smoothedPosition;

            transform.LookAt(_target);
        }
    }

}

