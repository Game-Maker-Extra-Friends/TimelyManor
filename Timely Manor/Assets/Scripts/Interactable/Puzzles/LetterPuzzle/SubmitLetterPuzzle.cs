using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitLetterPuzzle : MonoBehaviour
{
    public LetterPuzzleController _LetterPuzzleController;

    public void Submit()
    {
        //Debug.Log("Work");
        _LetterPuzzleController.CheckAnswer();
    }
}
