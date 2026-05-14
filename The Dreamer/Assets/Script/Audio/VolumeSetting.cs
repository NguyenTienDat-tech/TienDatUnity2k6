using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class VolumeSetting : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider vfxSlider;

    private void Awake()
    {
        float saveMusicVolume = PlayerPrefs.GetFloat("music", 1f);
        float saveVfxVolume = PlayerPrefs.GetFloat("vfx", 1f);

        musicSlider.value = saveMusicVolume;
        vfxSlider.value = saveVfxVolume;

        SetMusicVolume();
        SetVfxVolume();
    }


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        PlayerPrefs.SetFloat("music", volume);
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.Save();
    }


    public void SetVfxVolume()
    {
        float volume = vfxSlider.value;
        PlayerPrefs.SetFloat("vfx", volume);
        audioMixer.SetFloat("vfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.Save();
    }
}
