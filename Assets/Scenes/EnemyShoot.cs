using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject[] cannonsPositions;
    public GameObject cannonBall;
    public float force = 7000;

    public AudioSource ShootSound;

    private void Start()
    {
        StartCoroutine(ShootingPlayer());
    }

    IEnumerator ShootingPlayer()
    {
        var selectBarrel = UnityEngine.Random.Range(0, cannonsPositions.Length - 1);

        GameObject bullet = Instantiate(cannonBall, cannonsPositions[selectBarrel].transform.position, cannonsPositions[selectBarrel].transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = cannonsPositions[selectBarrel].transform.forward * force * Time.deltaTime;
        ShootSound.Play();

        yield return new WaitForSeconds(3);

        StartCoroutine(ShootingPlayer());
    }
}
