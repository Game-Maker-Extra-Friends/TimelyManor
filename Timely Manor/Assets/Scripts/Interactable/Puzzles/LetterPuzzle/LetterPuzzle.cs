using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterPuzzle : MonoBehaviour
{
    // Start is called before the first frame update


    public int currentImageNum = 0;

    public SpriteRenderer currentSprite;
    public Sprite correctSprite;

    [Tooltip("Tick if the image type is image and not sprite")]
    public bool image;  // For UI use
    public Image currentImage;

    public Sprite[] sprites;

    private void Start()
    {
        //Save save = Resources.Load<Save>("Saves/Save");
        //// If the flower lock is not zero then load
        //if (save.LoadSpritePuzzleState(name) != 0)
        //{
        //    currentImageNum = save.LoadSpritePuzzleState(name);
        //    updateImage();
        //}
        if (ES3.KeyExists(gameObject.name + "currentImage", "Saves/CombinationPuzzle.es3"))
        {
            currentImageNum = ES3.Load<int>(gameObject.name + "currentImage", "Saves/CombinationPuzzle.es3");
            updateImage();
        }

    }

    public void updateImage()
    {
        //Save save = Resources.Load<Save>("Saves/Save");
        for (int i = 0; i < sprites.Length; i++)
        {
            if(currentImageNum == i)
            {
                if (image == false)
                {
                    currentSprite.sprite = sprites[i];
                    Debug.Log("Sprite changed");
                }
                else
                {
                    currentImage.sprite = sprites[i];
                    Debug.Log("Image changed");
                }
            }
        }
        // save.SaveSpritePuzzleState(name, currentImageNum);
        ES3.Save(gameObject.name + "currentImage", currentImageNum, "Saves/CombinationPuzzle.es3");
    }

    //call on the + - button 
    public void updateCurrentImageUp()
    {
        //if we do up to F, put a limit of 6 and reset it back to 0
        
        if(currentImageNum < sprites.Length)
        {
            currentImageNum++;
        }
        else
        {
            currentImageNum = 0;
        }
    }
    public void updateCurrentImageDown()
    {
        if (currentImageNum > 0)
        {
            currentImageNum--;
        }
        else
        {
            currentImageNum = sprites.Length - 1;
        }
        
    }
}
