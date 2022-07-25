using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButton : MonoBehaviour
{
    [SerializeField]
    private LetterPuzzle _letterPuzzle;

    void OnMouseDown()
    {
        _letterPuzzle.updateCurrentLetterDown();
        Debug.Log("Update Down");
    }
}
