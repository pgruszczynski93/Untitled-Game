using UnityEngine;
using Unity.Entities;


public class PlayerRotationSystem : ComponentSystem
{

    bool _isInitCompleted = false;

    Vector3 _mousePosition;
    Camera _mainCamera;
    Ray _cameraRay;
    RaycastHit _hitInfo;
    LayerMask _layerMask;

    struct FilterGroup
    {
        public Transform Transform;
        public RotationComponent RotationComponent;
    }


    void Init()
    {
        if (!_isInitCompleted)
        {
            _mainCamera = Camera.main;
            _layerMask = LayerMask.GetMask("Floor"); 
            _isInitCompleted = true;
        }
    }

    protected override void OnUpdate()
    {

        Init();

        _mousePosition = Input.mousePosition;
        _cameraRay = _mainCamera.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_cameraRay, out _hitInfo ,100, _layerMask))
        {
            foreach (var entity in GetEntities<FilterGroup>())
            {
                Vector3 forward = _hitInfo.point - entity.Transform.position;
                Quaternion rotation = Quaternion.LookRotation(forward);

                entity.RotationComponent.Value = new Quaternion(0, rotation.y, 0, rotation.w);
            }
        }

    }
}
