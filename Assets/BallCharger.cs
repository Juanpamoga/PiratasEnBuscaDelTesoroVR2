using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCharger : MonoBehaviour
{
    private bool isReloaded;

     public AudioSource ShootSound;

    public GameObject shoteableCannonBall;
    public Transform barrel;

    public float force;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("ball"))
        {
            isReloaded = true;
        }

        if (isReloaded && other.gameObject.CompareTag("Fire"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(shoteableCannonBall, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody>().velocity = barrel.forward * force * Time.deltaTime; ;

        isReloaded = false;

        ShootSound.Play();
    }
}
