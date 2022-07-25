using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButton : MonoBehaviour
{
    [SerializeField]
    private LetterPuzzle _letterPuzzle;

    public void ChangeLetterDown()
    {
        _letterPuzzle.updateCurrentLetterDown();
        Debug.Log("Update Down");
    }
}
