﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButton : MonoBehaviour
{
    [SerializeField]
    private LetterPuzzle _letterPuzzle;

    public void ChangeLetterUp()
    {
        _letterPuzzle.updateCurrentLetterUp();
    }
}
