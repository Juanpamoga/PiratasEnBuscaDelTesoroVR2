using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSpawner : MonoBehaviour
{
    public GameObject spawner;
    public Vector3 spawnerPos;
    public GameObject containerBallsPrefab;

    public bool isEmpty;

    private void Start()
    {
        isEmpty = false;

        spawnerPos = transform.position;
    }

    private void Update()
    {
        //Debug.Log(isEmpty);
        if (isEmpty)
        {
            //SpawnContainer();
        }
    }

    private void SpawnContainer()
    {
        //Instantiate(containerBalls, spawnerpos);

        //isEmpty = false;
    }

    //private void Ont(Collision collision)
    //{
    //    if (!collision.gameObject.CompareTag("ball"))
    //    {
    //        empty = true;
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (true)
    //    {

    //    }
    //}

    ////private void OnCollisionStay(Collision collision)
    ////{
    ////    if (!collision.gameObject.CompareTag("ball"))
    ////    {
    ////        empty = true;
    ////    }

    ////    Debug.Log(collision.gameObject.tag);

    ////    if (collision.gameObject.tag != "ball")
    ////    {
    ////        isEmpty = true;
    ////    }
    ////}
    ///
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            Debug.Log(other.gameObject);
        }
    }
}
