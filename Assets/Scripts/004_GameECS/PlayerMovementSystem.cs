using UnityEngine;
using Unity.Entities;

public class PlayerMovementSystem : ComponentSystem
{

    Vector3 _moveVector;
    Vector3 _movePosition;

    float _dt;

    struct FilterGroup
    {
        public Rigidbody Rigidbody;
        public InputComponent InputComponent;
    }

    protected override void OnUpdate()
    {

        _dt = Time.deltaTime;

        foreach (var entity in GetEntities<FilterGroup>())
        {
            _moveVector = new Vector3(entity.InputComponent.Horizontal, 0f, entity.InputComponent.Vertical);
            _movePosition = entity.Rigidbody.position + _moveVector.normalized * 3 * _dt;

            entity.Rigidbody.MovePosition(_movePosition);
        }
    }
}
