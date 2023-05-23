using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<string> SoundsNames;
    public List<AudioClip> SoundsClips;
    public AudioSource Source;
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySound(string value)
    {
        if (!SoundsNames.Contains(value))
        {
            return;
        }
        else
        {
            for (int i = 0; i < SoundsNames.Count; i++)
            {
                if (SoundsNames[i] == value)
                {
                    Source.PlayOneShot(SoundsClips[i]);
                }
            }
        }
    }
}
