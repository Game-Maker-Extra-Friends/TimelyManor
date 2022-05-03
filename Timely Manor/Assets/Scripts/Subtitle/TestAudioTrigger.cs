using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioTrigger : MonoBehaviour
{
    public AudioObject clipToPlay;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //pass the audio object into the vocal player
            Vocal.instance.Say(clipToPlay);
        }
    }
}
