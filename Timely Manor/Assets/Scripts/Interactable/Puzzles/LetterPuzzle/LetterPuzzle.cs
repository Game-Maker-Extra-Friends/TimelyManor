using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzle : MonoBehaviour
{
    // Start is called before the first frame update


    public int currentLetter = 0;

    public GameObject LetterObj;
    public string _letter1;
    public string _letter2;
    public string _letter3;
    public string _letter4;
    public string _letter5;
    public string _letter6;

    public Renderer self;

    // Update is called once per frame
    void Update()
    {
        if (currentLetter == 0)
        {
            //Make this letter 1
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter1;
            //Debug.Log(currentLetter);
        }
        if (currentLetter == 1)
        {
            //Make this letter 2
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter2;
            //Debug.Log(currentLetter);
        }
        if (currentLetter == 2)
        {
            //Make this letter 3
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter3;
            //Debug.Log(currentLetter);
        }
        if (currentLetter == 3)
        {
            //Make this letter 4
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter4;
            // Debug.Log(currentLetter);
        }
        if (currentLetter == 4)
        {
            //Make this letter 5
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter5;
            // Debug.Log(currentLetter);
        }
        if (currentLetter == 5)
        {
            //Make this letter 6
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter6;
            // Debug.Log(currentLetter);
        }
    }

    //call on the + - button 
    public void updateCurrentLetterUp()
    {
        //if we do up to F, put a limit of 6 and reset it back to 0
        
        if(currentLetter < 6)
        {
            currentLetter++;
        }
        else
        {
            currentLetter = 0;
        }
    }
    public void updateCurrentLetterDown()
    {
        if (currentLetter > 0)
        {
            currentLetter--;
        }
        else
        {
            currentLetter = 5;
        }
        
    }
}
