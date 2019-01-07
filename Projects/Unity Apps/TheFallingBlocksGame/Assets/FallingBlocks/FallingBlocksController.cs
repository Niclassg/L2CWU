using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksController : MonoBehaviour
{
    [SerializeField] private FallingBlocksSpawner fallingBlocksSpawner;

    [SerializeField] private int blocksSpawnedPerMinute = 30;

    private Coroutine coroutine;

    public event Action BlockHitBottom;
    public event Action BlockHitPlayer;

    private List<FallingBlock> fallingBlocks = new List<FallingBlock>();

    private IEnumerator BlocksSpawnRoutine()
    {
        while (true)
        {
           var fallingBlock = fallingBlocksSpawner.SpawnRandomBlock();
            fallingBlock.BlockCollided += FallingBlock_BlockCollided;
            fallingBlocks.Add(fallingBlock);
            yield return new WaitForSeconds(1f/(blocksSpawnedPerMinute/60f));
        }
        
    }

    private void FallingBlock_BlockCollided(Collision obj)
    {
        if(obj.collider.tag == "Player")
        {
            if(BlockHitPlayer != null)
            {
                BlockHitPlayer.Invoke();
            }
        } else if (obj.collider.tag == "Bottom")
        {
            if(BlockHitBottom != null)
            {
                BlockHitBottom.Invoke();
            }
        }
    }

    public void StartSpawningBlocks()
    {
        coroutine = StartCoroutine(BlocksSpawnRoutine());
    }

    public void StopSpawningBlocks()
    {
        StopCoroutine(coroutine);
        foreach (var fallingBlock in fallingBlocks)
        {
            if(fallingBlock != null)
            {
                Destroy(fallingBlock.gameObject);
            }
        }
        fallingBlocks.Clear();

    }
}
