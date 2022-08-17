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


    public Sprite[] flowers;

    public Renderer self;


    public void updateImage()
    {
        for(int i = 0; i < flowers.Length; i++)
        {
            if(currentImageNum == i)
            {
                currentSprite.sprite = flowers[i];
            }
        }
    }

    //call on the + - button 
    public void updateCurrentImageUp()
    {
        //if we do up to F, put a limit of 6 and reset it back to 0
        
        if(currentImageNum < flowers.Length)
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
            currentImageNum = flowers.Length - 1;
        }
        
    }
}
