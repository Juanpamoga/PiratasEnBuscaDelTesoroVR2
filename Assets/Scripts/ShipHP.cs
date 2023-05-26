using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHP : MonoBehaviour
{

    public int shipHp = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            shipHp--;
        }
    }

    private void Update()
    {
        if (shipHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.AddComponent<HundimientoBarco>();
        Destroy(this);
    }
}