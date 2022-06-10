using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;//AudioSource�^�̕ϐ�audioSource��錾
    [SerializeField] private float _audioOffset;//�Ȃ̒x��
    

    void Start()
    {
        Invoke(nameof(AudioOffset), _audioOffset);//�ȍĐ��i_audioOffset���x���j
    }

    void AudioOffset()
    {
        _audioSource.Play();//�Ȃ��Đ�
    }
}
