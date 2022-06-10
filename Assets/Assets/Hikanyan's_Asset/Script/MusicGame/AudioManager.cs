using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;//AudioSourceŒ^‚Ì•Ï”audioSource‚ğéŒ¾
    [SerializeField] private float _audioOffset;//‹È‚Ì’x‰„
    

    void Start()
    {
        Invoke(nameof(AudioOffset), _audioOffset);//‹ÈÄ¶i_audioOffset•ª’x‰„j
    }

    void AudioOffset()
    {
        _audioSource.Play();//‹È‚ğÄ¶
    }
}
