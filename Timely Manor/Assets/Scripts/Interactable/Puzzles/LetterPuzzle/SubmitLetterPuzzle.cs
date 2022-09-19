using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitLetterPuzzle : MonoBehaviour
{
    public LetterPuzzleController _LetterPuzzleController;
    public GameObject objectName;

    public void Submit()
    {
        Debug.Log("Submit Work");
        _LetterPuzzleController.CheckAnswer();

        Save save = Resources.Load<Save>("Saves/Save");

        // If the letter lock is not zero then check asnwer (Placeholder Fix)
        if (save.LoadSpritePuzzleState(objectName.name) != 0)
        {
            _LetterPuzzleController.CheckAnswer();
        }
    }
}
