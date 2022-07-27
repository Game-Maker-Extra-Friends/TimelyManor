using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzle : MonoBehaviour
{
    // Start is called before the first frame update


    public int currentLetterNum = 0;

    public string currentLetterStr;

    public string correctLetter;

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
        if (currentLetterNum == 0)
        {
            //Make this letter 1
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter1;
            currentLetterStr = _letter1;
            //Debug.Log(currentLetter);
        }
        if (currentLetterNum == 1)
        {
            //Make this letter 2
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter2;
            currentLetterStr = _letter2;
            //Debug.Log(currentLetter);
        }
        if (currentLetterNum == 2)
        {
            //Make this letter 3
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter3;
            currentLetterStr = _letter3;
            //Debug.Log(currentLetter);
        }
        if (currentLetterNum == 3)
        {
            //Make this letter 4
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter4;
            currentLetterStr = _letter4;
            // Debug.Log(currentLetter);
        }
        if (currentLetterNum == 4)
        {
            //Make this letter 5
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter5;
            currentLetterStr = _letter5;
            // Debug.Log(currentLetter);
        }
        if (currentLetterNum == 5)
        {
            //Make this letter 6
            LetterObj.GetComponent<TMPro.TextMeshPro>().text = _letter6;
            currentLetterStr = _letter6;
            // Debug.Log(currentLetter);
        }
    }

    //call on the + - button 
    public void updateCurrentLetterUp()
    {
        //if we do up to F, put a limit of 6 and reset it back to 0
        
        if(currentLetterNum < 6)
        {
            currentLetterNum++;
        }
        else
        {
            currentLetterNum = 0;
        }
    }
    public void updateCurrentLetterDown()
    {
        if (currentLetterNum > 0)
        {
            currentLetterNum--;
        }
        else
        {
            currentLetterNum = 5;
        }
        
    }
}
