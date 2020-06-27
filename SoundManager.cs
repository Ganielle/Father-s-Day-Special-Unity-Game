using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip rightAnswer;
    [SerializeField] private AudioClip wrongAnswer;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip clapping;
    [SerializeField] private AudioClip electricity;
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource answerAudioSource;
    [SerializeField] private AudioSource buttonAudioSource;
    [SerializeField] public AudioSource ambienceSource;

    [Header("Values")]
    [SerializeField] private float maxTime;
    [SerializeField] private float loopTime;

    [Header("GameObjects")]
    [SerializeField] private GameObject greetings;

    private void Start()
    {
        backgroundAudioSource.clip = backgroundMusic;
        backgroundAudioSource.Play();
    }

    private void Update()
    {
        if (greetings.activeInHierarchy)
            backgroundAudioSource.volume = 0.3f;
        else
            backgroundAudioSource.volume = 1f;
    }

    private void LateUpdate()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        if (backgroundAudioSource.time >= maxTime)
        {
            backgroundAudioSource.time = Convert.ToInt32(loopTime);
            backgroundAudioSource.Play();
        }
    }

    public void PlayRightAnswer() => answerAudioSource.PlayOneShot(rightAnswer);

    public void PlayWrongAnswer() => answerAudioSource.PlayOneShot(wrongAnswer);

    public void ClickPlayButton() => buttonAudioSource.PlayOneShot(buttonSound);

    public void PlayClappingSound() => ambienceSource.PlayOneShot(clapping);

    public void PlayElectricitySound() 
    {
        ambienceSource.clip = electricity;
        ambienceSource.loop = true;
        ambienceSource.Play();
    }

    public void clearPlayElectrictySound()
    {
        ambienceSource.clip = null;
        ambienceSource.loop = false;
    }
}
