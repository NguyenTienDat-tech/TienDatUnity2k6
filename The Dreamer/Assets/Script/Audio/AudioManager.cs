using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Biến instance để tạo singleton
    public static AudioManager instance;

    //tạo biến lưu trữ audioSource
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    //tạo biến lưu trữ audioClip
    public AudioClip musicClip; //nhạc nền
    public AudioClip npcClip;
    public AudioClip gunShortClip;
    public AudioClip buttonClip;
    public AudioClip openChest;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
        musicAudioSource.loop = true;
    }

    public void PlayAudioClip(AudioClip vfxClip)
    {
        vfxAudioSource.clip = vfxClip;
        vfxAudioSource.PlayOneShot(vfxClip);
    }

    public void StopAudioClip()
    {
        vfxAudioSource.Stop();
    }

}
