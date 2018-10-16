using UnityEngine;
using Unity.Entities;

public class RotationSystem : ComponentSystem
{

    struct Data
    {
        public readonly int Length;
        public ComponentArray<RotationComponent> RotationComponents;
        public ComponentArray<Rigidbody> Rigidbodies;
    }

    [Inject] Data _data;

    protected override void OnUpdate()
    {

        for(int i=0; i<_data.Length; i++)
        {
            Quaternion rotation  = _data.RotationComponents[i].Value;
            _data.Rigidbodies[i].MoveRotation(rotation.normalized);
        }
    }
}
