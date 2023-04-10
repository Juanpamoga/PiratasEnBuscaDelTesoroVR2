using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightColor : MonoBehaviour
{
    public Gradient color;
    public float duration;
    public Light lightSource;
    
    void Update()
    {
        lightSource.color = color.Evaluate((Time.time % duration) / duration);
    }
}
