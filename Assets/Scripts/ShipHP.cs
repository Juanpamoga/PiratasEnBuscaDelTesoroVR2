using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHP : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            gameObject.GetComponentInParent<Ship>().Hp--;
        }
    }
}
