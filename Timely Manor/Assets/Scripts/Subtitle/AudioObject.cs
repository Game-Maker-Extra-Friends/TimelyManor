using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Audio Object", menuName = "Assest/New Audio Object")]
public class AudioObject : ScriptableObject
{

    //link clip and subtitle together
    public AudioClip clip;
    public string subtitle;
}
