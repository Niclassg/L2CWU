﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public event Action<Collision> BlockCollided;

    [SerializeField] private GameObject CollectParticlesPrefab;
    [SerializeField] private GameObject MissParticlesPrefab;

    bool collided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collided) return;

        if(BlockCollided != null)
        {
            BlockCollided.Invoke(collision);
        }

        if(collision.collider.tag == "Player")
        {
            collided = true;
            Collect();
        } else if(collision.collider.tag == "Bottom")
        {
            collided = true;
            Miss();
        }
    }

    private void Collect()
    {
        var particles = Instantiate(CollectParticlesPrefab);
        particles.transform.position = transform.position;
        Destroy(gameObject);

    }

    private void Miss()
    {
        var particles = Instantiate(MissParticlesPrefab);
        particles.transform.position = transform.position;
        Destroy(gameObject);
    }


}
