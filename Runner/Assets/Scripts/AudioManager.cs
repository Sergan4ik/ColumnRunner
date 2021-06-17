using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound : MonoBehaviour
{
    public float volume , pitch;
    public AudioMixerGroup group;
    public AudioClip clip;
    public bool loop = false , mode3d = false;
    public void PlaySound()
    {
        AudioManager.Instance.PlaySound(this);
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioMixerGroup musicGroup, effectsGroup;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        musicGroup.audioMixer.SetFloat("MusicVolume" , Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("MusicVolume")));
        effectsGroup.audioMixer.SetFloat("EffectsVolume" , Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("EffectsVolume")));
    }
    
    public void PlaySound(Sound sound)
    {
        GameObject srcOBJ = new GameObject();
        AudioSource src = srcOBJ.AddComponent<AudioSource>();
        src.volume = sound.volume;
        src.pitch = sound.pitch;
        src.loop = sound.loop;
        src.clip = sound.clip;
        src.outputAudioMixerGroup = sound.group;
        src.spatialBlend = (sound.mode3d) ? 1 : 0;
        src.Play();
    }
    public void PlaySoundAtPoint(Sound sound , Vector3 point)
    {
        GameObject srcOBJ = new GameObject();
        srcOBJ.transform.position = point;
        AudioSource src = srcOBJ.AddComponent<AudioSource>();
        src.volume = sound.volume;
        src.pitch = sound.pitch;
        src.loop = sound.loop;
        src.clip = sound.clip;
        src.outputAudioMixerGroup = sound.group;
        src.spatialBlend = (sound.mode3d) ? 1 : 0;
        src.Play();
    }

}
