using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private bool coroutineDone;
    public static AudioManager instance;

    void Awake()
    {
        //destroy the audioManager in another scene if it already exists to prevent double audio.
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        
        instance = this;

        coroutineDone = false;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
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
        Play("MusicPresent");
        //FadeOut("MusicPast", "MusicFuture");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        //find sounds in sound array, and find where sound.anme is equal to the name that is being played
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("The sound you are looking for: " + name + " is not found!");
            return;
        }

        s.source.Play();
        Debug.Log("playing sound: " + name);
    }

    public void Stop(string name)
    {
        //find sounds in sound array, and find where sound.anme is equal to the name that is being played
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("The sound you are looking for: " + name + " is not found!");
            return;
        }

        s.source.Stop();
        Debug.Log("Stopping sound: " + name);
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

        IEnumerator fadeOut = StartFade(s.audioMixerGroup.audioMixer, "music_volume", 2f, 0f, s, true);
        StartCoroutine(fadeOut);
        //Task fadeOut = new Task(StartFade(s.audioMixerGroup.audioMixer, "music_volume", 2f, 0f, s, true));
        Debug.Log("Fade out");
        //fadeOut.Start();
        
        StartCoroutine(StartFadeIn(nextName));
        coroutineDone = false;

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
        //Task fadeIn = new Task(StartFade(s.audioMixerGroup.audioMixer, "music_volume", 2f, 1f, s, false));
        //fadeIn.Start();
        IEnumerator fadeIn = StartFade(s.audioMixerGroup.audioMixer, "music_volume", 2f, 1f, s, false);
        StartCoroutine(fadeIn);
        //StartCoroutine(fadeIn);
        Debug.Log("fading in sound: " + name);
    }

    public IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume, Sound s, bool fadeOut)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);
        //Start the music so fade in can take place
        if (fadeOut == false)
        {
            s.source.Play();
        }
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }

        if (fadeOut)
        {
            s.source.Stop();
        }
        coroutineDone = true;
        yield break;
    }


    public IEnumerator StartFadeIn(string nextMusic)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Fade in");
        FadeIn(nextMusic);

        yield break;
    }
}
