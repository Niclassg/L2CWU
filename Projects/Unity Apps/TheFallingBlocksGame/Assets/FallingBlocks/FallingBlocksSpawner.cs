using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksSpawner : MonoBehaviour
{
    [SerializeField] private FallingBlock fallingBlockPrefab;

    [SerializeField] private float spawnLimitLeft;
    [SerializeField] private float spawnLimitRight;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        Vector3 leftCube = new Vector3(-spawnLimitLeft, 7.5f);
        Vector3 rightCube = new Vector3(spawnLimitRight, 7.5f);

        Gizmos.DrawLine(leftCube, rightCube);
        Gizmos.DrawCube(leftCube, Vector3.one / 5);
        Gizmos.DrawCube(rightCube, Vector3.one / 5);
    }

 
    public FallingBlock SpawnRandomBlock()
    {
        var fallingBlock = Instantiate(fallingBlockPrefab);
        fallingBlock.transform.position = GetRandomPosition();

        return fallingBlock;
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-spawnLimitLeft, spawnLimitRight), 8f);
    }


}
