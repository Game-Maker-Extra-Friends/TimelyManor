using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectLightBulb : MonoBehaviour
{
    public bool on = false;
    void Start()
    {
        on = false;
    }

    public void turnOn()
    {
        on = true;
        Debug.Log("The thing has turn on");
    }
}
