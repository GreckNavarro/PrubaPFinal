using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "EffectSound", menuName = "ScriptableObject/Audio/EffectSound", order = 4)]

public class EffectsSO : ScriptableObject
{
    [SerializeField] AudioClip myAudio;
    [SerializeField] AudioMixerGroup myGroup;

    public void StartSoundSelection() // O(1)
    {
        GameObject audioGameObject = new GameObject(); // 2
        AudioSource myAudioSource = audioGameObject.AddComponent<AudioSource>(); // 2

        myAudioSource.outputAudioMixerGroup = myGroup; // 2
        myAudioSource.PlayOneShot(myAudio); // 1
        Destroy(audioGameObject, 0.5f); // 1
        
    }
}
