using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzleController : MonoBehaviour
{
    public LetterPuzzle[] _letters;

    bool _correctCombination = false;


    //ref to light
    [SerializeField]
    private CorrectLightBulb _lightBulb;

    public Transform lightBulb;

    public AudioSource fail;
    public AudioSource success;
    public void CheckAnswer()
    {
        foreach(LetterPuzzle lp in _letters)
        {
            if(lp.currentLetterStr == lp.correctLetter)
            {
                _correctCombination = true;
            }
            else
            {
                _correctCombination = false;
                break;
            }
        }


        if (_correctCombination)
        {
            //_lightBulb.turnOn();
            success.Play();
        }
        else 
        {
            fail.Play();
        }
        // 
        //if (_letter1.currentLetterNum == 2 && _letter2.currentLetterNum == 2 && _letter3.currentLetterNum == 1 && _letter4.currentLetterNum == 5 && _letter5.currentLetterNum == 1)
        //{
        //    var cubeRenderer = lightBulb.GetComponent<Renderer>();
        //    cubeRenderer.material.SetColor("_Color", Color.green);

        //    _lightBulb.turnOn();
        //    success.Play();
        //}
        //else
        //{
        //    fail.Play();
        //}
    }
}
