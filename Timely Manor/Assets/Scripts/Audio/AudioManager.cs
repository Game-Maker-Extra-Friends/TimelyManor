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
        Play("MusicPast");
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

    public void FadeOut(string currentName, string nextName)
    {
        //find sounds in sound array, and find where sound.anme is equal to the name that is being played
        Sound s = Array.Find(sounds, sound => sound.name == currentName);

        if (s == null)
        {
            Debug.LogWarning("The sound you are looking for: " + currentName + " is not found!");
            return;
        }

        IEnumerator fadeOut = StartFade(s.audioMixerGroup.audioMixer, "music_volume", 4f, 0f);
        StartCoroutine(fadeOut);
        FadeIn(nextName);
        Debug.Log("fading out sound: " + currentName);
    }


    public void FadeIn(string name)
    {
        //find sounds in sound array, and find where sound.anme is equal to the name that is being played
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("The sound you are looking for: " + name + " is not found!");
            return;
        }

        IEnumerator fadeIn = StartFade(s.audioMixerGroup.audioMixer, "music_volume", 4f, 1f);
        StartCoroutine(fadeIn);
        Debug.Log("fading in sound: " + name);
    }

    public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }

        yield break;
    }

}
