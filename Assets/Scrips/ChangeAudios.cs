using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudios : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
    [SerializeField] AudioSource audiosource;
    [SerializeField] ScoreManager score;

    private void Start()
    {
        score.InvokeBoss += ChangeAudioClip;
        audiosource.clip = audios[0];
        audiosource.Play();
    }

    public void ChangeAudioClip()
    {
        if (audios[0])
        {
            audiosource.clip = audios[1];
            audiosource.Play();
        }
        else if (audios[1])
        {
            audiosource.clip = audios[0];
            audiosource.Play();
        }
    }
}
