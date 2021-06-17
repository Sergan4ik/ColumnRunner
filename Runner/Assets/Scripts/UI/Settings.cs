using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioMixerGroup MusicGroup, EffectGroup;
    [SerializeField] Slider MusicSlider, EffectSlider;
    [SerializeField] TMP_Dropdown qualityDropDown;
    
    public void Awake()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        EffectSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        qualityDropDown.value = PlayerPrefs.GetInt("QualitySettings");
    }

    public void ChangeMusicVolume(float volume)
    {
        MusicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void ChangeEffectsVolume(float volume)
    {
        EffectGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
    public void ChangeQualitySetting(int qualityIdx)
    {
        QualitySettings.SetQualityLevel(qualityIdx + 1);
        PlayerPrefs.SetInt("QualitySettings", qualityIdx);
    }
}
