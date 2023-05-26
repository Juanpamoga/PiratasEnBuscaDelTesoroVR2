using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public GameObject[] sandgroups;
    public GameObject chest;

    Vector3 chestOriginalPos;

    public bool canDig = true;

    public int count;

    private void Start()
    {
        chestOriginalPos = chest.transform.position;

        count = sandgroups.Length;
    }

    ////private void OnCollisionExit(Collision collision)
    ////{
    ////    if (collision.gameObject.CompareTag("shovel"))
    ////    {
    ////        Debug.Log("coll exit");
    ////        RemoveGroupSand();
    ////        PullUpChest();
    ////    }
    ////}

    private void OnTriggerExit(Collider other)
    {
        if (canDig && other.gameObject.CompareTag("shovel"))
        {
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
        //foreach (var sand in sandgroups)
        //{
        //    if (sand.active)
        //    {
        //        sand.gameObject.SetActive(false);
        //    }
        //}

        canDig = false;
        //count = sandgroups.Length;
        sandgroups[count - 1].SetActive(false);
        count--;

        StartCoroutine(WaitCD());
    }

    IEnumerator WaitCD()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //RemoveGroupSand();

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        canDig = true;
    }
}