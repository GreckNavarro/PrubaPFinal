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

    public void ChangeAudioClip() // TIEMPO ASINTÓTICO O(1)
    {
        if (audios[0]) // 1 + 4 = 5
        {
            audiosource.clip = audios[1]; //3
            audiosource.Play(); // 1
        }
        else if (audios[1]) // 1 + 4 = 5
        {
            audiosource.clip = audios[0]; //3
            audiosource.Play(); // 1
        }
    }
}
