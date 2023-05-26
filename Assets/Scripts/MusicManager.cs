using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject audioObject;
    public float fadeDuration = 1.0f; // Duración del fade en segundos
    private AudioSource[] audioSources;

    public float MaxVolume;

    private void Start()
    {
        audioSources = audioObject.GetComponentsInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Play();
                StartCoroutine(FadeIn(audioSource));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Stop();
                StartCoroutine(FadeOut(audioSource));
            }
        }
    }

    private System.Collections.IEnumerator FadeIn(AudioSource audioSource)
    {
        float currentTime = 0.0f;
        audioSource.volume = 0.0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0.0f, MaxVolume, currentTime / fadeDuration);
            yield return null;
        }

        audioSource.volume = MaxVolume;
    }

    private System.Collections.IEnumerator FadeOut(AudioSource audioSource)
    {
        float currentTime = 0.0f;
        float startVolume = audioSource.volume;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0.0f, currentTime / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0.0f;
        audioSource.Stop();
    }
    
}
