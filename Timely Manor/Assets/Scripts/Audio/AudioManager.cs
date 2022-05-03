using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        //destroy the audioManager in another scene if it already exists to prevent double audio.
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            //set each of the sound in the manager with the settings set in the inspector.
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //Set each sound to their settings from inspector
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
    }

   

    private void Start()
    {
        //Test Play sound
        Play("Music");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        //find sounds in sound array, and find where sound.anme is equal to the name that is being played
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("The sound you are looking for: " + name + " is not found!");
            return;
        }

        s.source.Play();
        Debug.Log("playing sound: " + name);
    }
}
