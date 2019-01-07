using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksController : MonoBehaviour
{
    [SerializeField] private FallingBlocksSpawner fallingBlocksSpawner;

    [SerializeField] private int blocksSpawnedPerMinute = 30;

    private Coroutine coroutine;


    private IEnumerator BlocksSpawnRoutine()
    {
        while (true)
        {
            fallingBlocksSpawner.SpawnRandomBlock();
            yield return new WaitForSeconds(1f/(blocksSpawnedPerMinute/60f));
        }
        
    }

    public void StartSpawningBlocks()
    {
        coroutine = StartCoroutine(BlocksSpawnRoutine());
    }
}
