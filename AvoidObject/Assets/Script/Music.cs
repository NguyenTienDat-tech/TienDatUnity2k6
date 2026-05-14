using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //Taọ biến lưu trữ audio source
    public AudioSource musicAudioSource; //chuyên phát nhạc nền

    //Tạo biến lưu trữ Audio clip
    public AudioClip musicClip;


    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = true; //duy trì âm thanh
        musicAudioSource.Play(); 
    }

   
}
