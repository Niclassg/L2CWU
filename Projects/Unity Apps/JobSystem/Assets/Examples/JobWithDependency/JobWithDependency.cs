using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace JobWithDependencyNamespace
{
    public class JobWithDependency : MonoBehaviour
    {
        public struct AJob : IJob
        {
            public float a;
            public NativeArray<float> result;
            
            public void Execute()
            {
                result[0] = result[0] + a;
            }
        }

    
            void Start()
        {
            NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

            result[0] = 2;
            
            AJob jobData1 = new AJob {result = result, a = 5};
            
            AJob jobData2 = new AJob {result = result, a = 3};
            
            JobHandle firstJobHandle = jobData1.Schedule();
          
            JobHandle secondJobHandle = jobData2.Schedule(firstJobHandle);

            secondJobHandle.Complete();
            
            Debug.Log(result[0]);
            
            result.Dispose();
        }

        void Update()
        {
        
        }
    }

}

