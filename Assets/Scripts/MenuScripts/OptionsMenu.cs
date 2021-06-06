using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMaster (float volume)
    {
        audioMixer.SetFloat("Master Volume", volume);
        audioMixer.SetFloat("Music Volume", volume);
        audioMixer.SetFloat("SFX Volume", volume);
    }
    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music Volume", volume);
    }
    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFX Volume", volume);
    }
}
