using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{
    public class CameraController : MonoBehaviour
    {
        float _dt;
        [SerializeField] float _smoothFactor;

        Vector3 _offset;
        Vector3 _targetPosition;
        Vector3 _smoothedPosition;
        [SerializeField] Transform _target;

        void Start()
        {
            _offset = _target.position - transform.position;
        }

        void FixedUpdate()
        {
            MoveCamera();
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

