using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private int hp = 3;
    private bool isAlive;

    public int Hp { get => hp; set => hp = value; }

    private void Update()
    {
        if (isAlive && Hp<=0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }
}
