using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{

    [SerializeField] private float distanceBetweenLives = 1f;

    [SerializeField] private int livesAmount = 3;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < livesAmount; i++)
        {
            Gizmos.DrawCube(transform.position + Vector3.right * i * distanceBetweenLives, Vector3.one/10f);
        }

    }

    public List<Vector3> GetLivesUILocations()
    {
        List<Vector3> livesUILocations = new List<Vector3>(livesAmount);

        for (int i = 0; i < livesAmount; i++)
        {
            livesUILocations.Add(new Vector3(transform.position.x + (i * distanceBetweenLives), transform.position.y));
        }

        return livesUILocations;
    }
}
