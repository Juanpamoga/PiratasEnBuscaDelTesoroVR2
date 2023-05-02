using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMapLocator : MonoBehaviour
{
    public Transform player, mapToken;

    public float scale;
    
    void Update()
    {
        MoveToken();
    }

    void MoveToken()
    {
        mapToken.localPosition = new Vector3(player.position.x, 0f, player.localPosition.z)*scale;
        mapToken.localPosition += new Vector3(0f, 0.052f, 0f);
    }
}
