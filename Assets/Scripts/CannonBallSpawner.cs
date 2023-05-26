using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSpawner : MonoBehaviour
{
    public Transform spawnerpos;
    public GameObject containerBalls;

    public bool empty;

    private void Start()
    {
        empty = false;
    }

    private void Update()
    {
        if (empty)
        {
            SpawnContainer();
        }
    }

    private void SpawnContainer()
    {
        Instantiate(containerBalls, spawnerpos);

        empty = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ball"))
        {
            empty = true;
        }
    }
}
