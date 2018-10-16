using UnityEngine;
using Unity.Entities;

class InputSystem : ComponentSystem
{

    float _horizontal;
    float _vertical;

    private struct Data
    {
        public readonly int Length;
        public ComponentArray<InputComponent> InputComponents;
    }

    [Inject] Data _data;

    protected override void OnUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        for (int i = 0; i < _data.Length; i++)
        {
            _data.InputComponents[i].Horizontal = _horizontal;
            _data.InputComponents[i].Vertical = _vertical;
        }
    }
}
