using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ChannelManager", menuName = "ScriptableObject/Audio/ChannelManager", order = 3)]

public class SoundSO : ScriptableObject
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private string channelVolumen;
    [SerializeField] private float currentVolume;
    [SerializeField] private bool isMuted;
    public void UpddateVolume(Slider mySlider)
    {
        currentVolume = mySlider.value;
        myMixer.SetFloat(channelVolumen, Mathf.Log10(currentVolume) * 20f);
    }

    public void Muted()
    {
        if (isMuted)
        {
            myMixer.SetFloat(channelVolumen, Mathf.Log10(currentVolume) * 20f);
            isMuted = false;
        }
        else
        {
            myMixer.SetFloat(channelVolumen, -80);
            isMuted = true;
        }

    }
}
