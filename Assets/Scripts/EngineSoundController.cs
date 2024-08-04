using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundController : MonoBehaviour
{
    private float armState = 0.0f;
    private float swingState = 0.0f;
    private float bucketState = 0.0f;
    private float boomState = 0.0f;
    private float leftWheelState = 0.0f;
    private float rightWheelState = 0.0f;
    private AudioSource audioSource;

    [SerializeField] private float fadeOutDuration = 1.0f;
    [SerializeField] private float fadeInDuration = 0.2f; // Shorter fade-in duration
    private bool isMoving = false;
    private Coroutine fadeCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        armState = zx120Controller.armDirection;
        swingState = zx120Controller.swingDirection;
        bucketState = zx120Controller.bucketDirection;
        boomState = zx120Controller.boomDirection;
        leftWheelState = zx120Controller.leftWheel;
        rightWheelState = zx120Controller.rightWheel;

        bool currentlyMoving = armState != 0.0f || swingState != 0.0f || bucketState != 0.0f || 
                               boomState != 0.0f || leftWheelState != 0.0f || rightWheelState != 0.0f;

        if (currentlyMoving != isMoving)
        {
            isMoving = currentlyMoving;
            if (isMoving)
            {
                StartFadeIn();
            }
            else
            {
                StartFadeOut();
            }
        }
    }

    private void StartFadeIn()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeVolume(audioSource.volume, 1.0f, fadeInDuration));
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StartFadeOut()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeVolume(audioSource.volume, 0.0f, fadeOutDuration));
    }

    private IEnumerator FadeVolume(float startVolume, float endVolume, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            audioSource.volume = Mathf.Lerp(startVolume, endVolume, t);
            yield return null;
        }

        audioSource.volume = endVolume;

        if (endVolume == 0f)
        {
            audioSource.Stop();
        }
    }
}