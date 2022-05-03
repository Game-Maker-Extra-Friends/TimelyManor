using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocal : MonoBehaviour
{
    private AudioSource audioSource;

    public static Vocal instance;


    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Say(AudioObject clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(clip.clip);

        //pass the subtitle text and the length of the clip to clear the subtitle.
        SubtitleUI.instance.SetSubtitle(clip.subtitle, clip.clip.length);
    }
}
