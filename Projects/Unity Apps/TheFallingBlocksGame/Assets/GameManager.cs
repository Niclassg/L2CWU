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
        StartGame();
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
