using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceScript : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;


    public AudioSource Fail;
    public AudioSource Success;

    private void Start()
    {
        codeLength = code.Length;

    }

    public void CheckCode()
    {
        if (attemptedCode == code)
        {
            Success.Play();
        }
        else
        {
            Debug.Log("wrong code");
            Fail.Play();
            attemptedCode = null;
            placeInCode = 0;
        }
    }


    public void SetValue(string value)
    {
        placeInCode++;

        //value added to attempted code when button is hit if it's less than code length
        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
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
