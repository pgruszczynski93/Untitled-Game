using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace ECSTest
{
    public class SceneManager : MonoBehaviour
    {
        public int boxCount;

        TransformAccessArray transforms;
        MovementJob movementJob;
        JobHandle moveHandle;

        void Start()
        {
            transforms = new TransformAccessArray(0, -1);
        }

        void OnDisable()
        {
            moveHandle.Complete();
            transforms.Dispose();
        }

        void Update()
        {
            moveHandle.Complete();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddCubes();
            }

            movementJob = new MovementJob()
            {
                speed = 5,
                deltaTime = Time.deltaTime
            };

            moveHandle = movementJob.Schedule(transforms);
            JobHandle.ScheduleBatchedJobs();
        }

        void AddCubes()
        {

            moveHandle.Complete();

            transforms.capacity = transforms.length + boxCount;

            for (int i = 0; i < boxCount; i++)
            {
                float xVal = Random.Range(-5, 5);
                float zVal = Random.Range(-5, 5);

                Vector3 pos = new Vector3(xVal, 0, zVal);
                Quaternion rot = Quaternion.identity;

                var obj = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), pos, rot);

                transforms.Add(obj.transform );
            }
        }
    }
}
