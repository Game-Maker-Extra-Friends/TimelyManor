using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzleController : MonoBehaviour
{
    //Reference to all the letters
    [SerializeField]
    private LetterPuzzle _letter1;
    [SerializeField]
    private LetterPuzzle _letter2;
    [SerializeField]
    private LetterPuzzle _letter3;
    [SerializeField]
    private LetterPuzzle _letter4;
    [SerializeField]
    private LetterPuzzle _letter5;

    //ref to light
    [SerializeField]
    private CorrectLightBulb _lightBulb;

    public Transform lightBulb;

    public AudioSource fail;
    public AudioSource success;
    // Update is called once per frame
    public void CheckAnswer()
    {
        // 
        if (_letter1.currentLetter == 2 && _letter2.currentLetter == 2 && _letter3.currentLetter == 1 && _letter4.currentLetter == 5 && _letter5.currentLetter == 1)
        {
            var cubeRenderer = lightBulb.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);

            _lightBulb.turnOn();
            success.Play();
        }
        else
        {
            fail.Play();
        }
    }
}
