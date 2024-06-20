using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{   
    [SerializeField]
    private AudioMixer soundMixer;

     public void SoundSliderChange(float value)
     {
        Debug.Log(value);
     }
}
