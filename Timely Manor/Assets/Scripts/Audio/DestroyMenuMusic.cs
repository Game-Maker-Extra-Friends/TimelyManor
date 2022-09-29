using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMenuMusic : MonoBehaviour
{
    private GameObject music;
    public string musicObjectName;

    private void Start()
    {
        music = GameObject.Find(musicObjectName);
    }

    private void OnDestroy()
    {
        Destroy(music);
    }

}
