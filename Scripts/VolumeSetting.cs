using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private AudioMixer soundMixer;
    [SerializeField] private Slider soundSlider;

    public void SetMusicVolume()
    {
        float volumeMusic = musicSlider.value;
        musicMixer.SetFloat("musicVal", Mathf.Log10(volumeMusic)*20);
    }

    public void SetSoundVolume()
    {
        float volumeSound = soundSlider.value;
        soundMixer.SetFloat("soundVal", Mathf.Log10(volumeSound)*20);
    }
}
