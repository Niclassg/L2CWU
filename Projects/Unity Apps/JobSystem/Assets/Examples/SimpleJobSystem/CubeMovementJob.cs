using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine.Jobs;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class CubeMovementJob : MonoBehaviour
{
    [SerializeField] private int count = 3000;
    [SerializeField] private float speed = 20;
    [SerializeField] private int spawnRange = 50;
    [SerializeField] private bool useJob = false;

    private Transform[] transforms;
    private Vector3[] targets;
    private List<GameObject> cubes = new List<GameObject>();
    private TransformAccessArray transAccArr;
    private NativeArray<Vector3> nativeTargets;


    struct MovementJob : IJobParallelForTransform
    {
        public float DeltaTime;
        public NativeArray<Vector3> Targets;
        public float Speed;

        public void Execute(int i, TransformAccess transform)
        {
            transform.position = Vector3.Lerp(transform.position, Targets[i], DeltaTime / Speed);
            
        }
    }

    private MovementJob job;
    private JobHandle newJobHandle;

    private void Start()
    {
        transforms = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubes.Add(obj);
            obj.transform.position = Random.insideUnitSphere * spawnRange;
            obj.GetComponent<MeshRenderer>().material.color = Color.green;
            Destroy(obj.GetComponent<BoxCollider>());
            transforms[i] = obj.transform;
        }
        
        targets = new Vector3[transforms.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = Random.insideUnitSphere * spawnRange;
            
        }
    }

    private void Update()
    {
        transAccArr = new TransformAccessArray(transforms);
        nativeTargets = new NativeArray<Vector3>(targets, Allocator.TempJob);

        if (useJob)
        {
            job = new MovementJob();
            job.DeltaTime = Time.deltaTime;
            job.Targets = nativeTargets;
            job.Speed = speed;
            newJobHandle = job.Schedule(transAccArr);
        }
        else
        {
            for (int i = 0; i < transAccArr.length; i++)
            {
                cubes[i].transform.position =
                    Vector3.Lerp(cubes[i].transform.position, targets[i], Time.deltaTime / speed);
            }
        }
        
    }

    private void LateUpdate()
    {
            newJobHandle.Complete();
            transAccArr.Dispose();
            nativeTargets.Dispose();
    }
}
