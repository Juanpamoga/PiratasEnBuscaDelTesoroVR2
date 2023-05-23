using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public GameObject[] sandgroups;
    public GameObject chest;

    Vector3 chestOriginalPos;

    private void Start()
    {
        chestOriginalPos = chest.transform.position;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("shovel"))
        {
            //Debug.Log("coll exit");
            RemoveGroupSand();
            PullUpChest();
        }
    }

    private void PullUpChest()
    {
        Vector3 newPos = chestOriginalPos;
        newPos.y += 1;

        chest.transform.position = newPos;
    }

    private void RemoveGroupSand()
    {
        foreach (var sand in sandgroups)
        {
            if (sand.active)
            {
                sand.gameObject.SetActive(false);
            }
        }
    }
}