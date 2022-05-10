using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    //for placing green/red light object.
    public Transform lightBulb;
    public CorrectLightBulb _light;

    public AudioSource Fail;
    public AudioSource Success;

    public GameObject showNumber;
    //to show input password
    private void Start()
    {
        codeLength = code.Length;
        
    }

    public void CheckCode()
    {
        if(attemptedCode == code)
        {
            Success.Play();
            greenLight();
        }
        else
        {
            Debug.Log("wrong code");
            Fail.Play();
            attemptedCode = "";
            showNumber.GetComponent<TMPro.TextMeshPro>().text = attemptedCode;
            placeInCode = 0;
        }
    }

    //make the light green
    void greenLight()
    {
        var cubeRenderer = lightBulb.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);

        //Set the light on to true for win condition
        _light.turnOn();
    }

    public void SetValue(string value)
    {
        placeInCode++;

        //value added to attempted code when button is hit if it's less than code length
        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
            showNumber.GetComponent<TMPro.TextMeshPro>().text = attemptedCode;
        }

        //check if the length of code match the code length, if it does it checks code then reset the attpempted code (the one player put in)
        //if (placeInCode == codeLength)
        //{
        //    CheckCode();

        //    //reset the attempted codce and place incode back to default so player can try again.
        //    attemptedCode = "";
        //    placeInCode = 0;

        //    //put if in here for success and fail sound
        //}
    }
}
