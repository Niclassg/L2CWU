using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace ParallelForExampleNamespace
{
    public class ParallelForExample : MonoBehaviour
    {

        public JobHandle handle;
        public NativeArray<float> result;

        private bool runJobs = true;
        
        public struct SomeParallelJob : IJobParallelFor
        {
            public NativeArray<float> Values;
            public float DeltaTime;
            
            public void Execute(int index)
            {
                Values[index] += DeltaTime;
            }
        }
        
        void Start()
        {
            result = new NativeArray<float>(100, Allocator.Persistent);
            for (int i = 0; i < result.Length; i++)
            {
                result[0] = 0;
            } 
        }
        
        void Update()
        {
            if (runJobs)
            {
                SomeParallelJob jobData = new SomeParallelJob {Values = result, DeltaTime = Time.deltaTime};

                handle = jobData.Schedule(result.Length, 1);

            }
            
        }

        private void LateUpdate()
        {
            if (runJobs)
            {
                handle.Complete();
                if (result.Max() > 2f)
                {
                    runJobs = false;
                    
                    foreach (var f in result)
                    {
                        Debug.Log(f);
                    }
                    
                    Debug.Log(result.Max());
                    result.Dispose();
                }
            }
            
            
        }

    }

}

