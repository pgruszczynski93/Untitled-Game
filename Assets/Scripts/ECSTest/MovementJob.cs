using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;

namespace ECSTest{

    public struct MovementJob : IJobParallelForTransform
    {
        public float speed;
        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            Vector3 pos = transform.position;

            pos += speed * deltaTime * new Vector3(0,1,0);

            transform.position = pos;
        }
    }

}