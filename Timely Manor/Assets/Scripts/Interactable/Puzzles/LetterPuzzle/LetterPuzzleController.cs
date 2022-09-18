using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzleController : MonoBehaviour
{
    public LetterPuzzle[] _letters;

    public bool _correctCombination = false;


    //ref to light
    [SerializeField]
    private CorrectLightBulb _lightBulb;

    public Transform lightBulb;

    public AudioSource fail;
    public AudioSource success;

    //private void Start()
    //{
    //    Save save = Resources.Load<Save>("Saves/Save");
    //    // If the flower lock is not zero then load
    //    if (save.LoadSpritePuzzleState(name) != 0)
    //    {
    //        currentImageNum = save.LoadSpritePuzzleState(name);
    //        updateImage();
    //    }

    //}

    public void CheckAnswer()
    {
        foreach(LetterPuzzle lp in _letters)
        {
            if(lp.image == false) // If the spriteRenderer is used instead of image (World)
            {
                if(lp.currentSprite.sprite == lp.correctSprite)
                {
                    _correctCombination = true;
                }
                else
                {
                    _correctCombination = false;
                    break;
                }
            }
            else // If Image is used instead of SpriteRenderer (UI)
            {
                if (lp.currentImage.sprite == lp.correctSprite)
                {
                    _correctCombination = true;
                }
                else
                {
                    _correctCombination = false;
                    break;
                }
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
    }
}
