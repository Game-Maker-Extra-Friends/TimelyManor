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

    public bool combinationFromLoad = false;

    private void Start()
    {
        if (ES3.KeyExists(gameObject.name + "correctCombination", "Saves/CombinationPuzzle.es3"))
        {
            _correctCombination = ES3.Load<bool>(gameObject.name + "correctCombination", "Saves/CombinationPuzzle.es3");
            if(_correctCombination == true)
            {
                combinationFromLoad = true;
                Debug.Log("The Correct combination is: " + _correctCombination + "The Combination from load is: " +  combinationFromLoad);
                LockBoxController.instance.UpdateBox();
            }
        }

    }

    public void CheckAnswer()
    {
        if(combinationFromLoad == false)
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
        }

        // Only play sound if it wasn't from loading
        if (_correctCombination == true && combinationFromLoad == false)
        {
            //_lightBulb.turnOn();
            AudioManager.instance.Play("LockUnlocked");
        }
        else if(_correctCombination == false && combinationFromLoad == false)
        {
            AudioManager.instance.Play("LockShaking");
        }
        ES3.Save(gameObject.name + "correctCombination", _correctCombination, "Saves/CombinationPuzzle.es3");
    }
}
