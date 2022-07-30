using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class LoadOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Load volume since volume option doesn't carry over scenes
    void Start()
    {
        // Audio Saves
        if (ES3.KeyExists("MasterVolume", "Options/AudioOptions.es3"))
        {
            float volume = ES3.Load<float>("MasterVolume", "Options/AudioOptions.es3");
            audioMixer.SetFloat("master_volume", volume);
        }
        if (ES3.KeyExists("SFXVolume", "Options/AudioOptions.es3"))
        {
            float volume = ES3.Load<float>("SFXVolume", "Options/AudioOptions.es3");
            audioMixer.SetFloat("sfx_volume", volume);
        }
        if (ES3.KeyExists("MusicVolume", "Options/AudioOptions.es3"))
        {
            float volume = ES3.Load<float>("MusicVolume", "Options/AudioOptions.es3");
            audioMixer.SetFloat("music_volume", volume);
        }
    }

}
