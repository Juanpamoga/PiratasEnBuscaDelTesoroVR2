using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject ball;

    public bool empty;

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ball"))
        {
            empty = true;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        if (empty)
        {
            Instantiate(ball, spawner.transform);
        }
    }
}
