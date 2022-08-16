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
        Save save = Resources.Load<Save>("Saves/Save");
        Debug.Log(save.name);
        audioMixer.SetFloat("master_volume", save.masterVolume);
        audioMixer.SetFloat("sfx_volume", save.sfxVolume);
        audioMixer.SetFloat("music_volume", save.musicVolume);
    }

}
