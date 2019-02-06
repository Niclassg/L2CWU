using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace FirstJobNamespace
{
    public class FirstJob : MonoBehaviour
    {
        public struct SomeJob : IJob
        {
            public float a;
            public float b;
            public NativeArray<float> result;

            public void Execute()
            {
                result[0] = a + b;
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
            NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);
    
            SomeJob jobData = new SomeJob {a = 5, b = 3, result = result};

            JobHandle handle = jobData.Schedule();

            handle.Complete();

            float resultOfJob = result[0];
        
            Debug.Log(resultOfJob);
        
            result.Dispose();
        }
    }

}

