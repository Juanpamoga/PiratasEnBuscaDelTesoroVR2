using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private GameObject barrelPrefab, barrelPrefabContainer, ballPrefab;

    public GameObject spawnerPos;

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        count++;
    }

    private void Update()
    {
        if (count >= 1)
        {
            ReespawnAmmo();
            
        }
    }

    private void ReespawnAmmo()
    {
        //Instantiate(barrelPrefab, gameObject.transform.position, Quaternion.identity, barrelPrefabContainer.transform);

        Instantiate(ballPrefab, spawnerPos.transform.position, Quaternion.identity, barrelPrefab.transform);
        //Instantiate(ballPrefab, spawnerPos.transform.position, Quaternion.identity, barrelPrefab.transform);
        //Instantiate(ballPrefab, spawnerPos.transform.position, Quaternion.identity, barrelPrefab.transform);

        count = 0;

        //Destroy(this.gameObject);
    }
}
