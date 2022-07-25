using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitLetterPuzzle : MonoBehaviour
{
    public LetterPuzzleController _LetterPuzzleController;

    void OnMouseDown()
    {
        //Debug.Log("Work");
        _LetterPuzzleController.CheckAnswer();
    }
}
