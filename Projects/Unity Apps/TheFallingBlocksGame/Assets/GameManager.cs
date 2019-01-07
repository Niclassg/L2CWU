using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LivesSpawner livesSpawner;
    [SerializeField] FallingBlocksController fallingBlocksController;

    void Start()
    {
        fallingBlocksController.BlockHitPlayer += FallingBlocksController_BlockHitPlayer;
        fallingBlocksController.BlockHitBottom += FallingBlocksController_BlockHitBottom;

        StartGame();
    }

    private void FallingBlocksController_BlockHitBottom()
    {
        livesSpawner.RemoveOneLive();
        if(livesSpawner.LiveUIElements.Count == 0)
        {
            fallingBlocksController.StopSpawningBlocks();
            StartGame();
        }
    }

    private void FallingBlocksController_BlockHitPlayer()
    {
        //Maybe give player a point --
    }

    private void StartGame()
    {
        livesSpawner.SpawnLives();
        fallingBlocksController.StartSpawningBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
