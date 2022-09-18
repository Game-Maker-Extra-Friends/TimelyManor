using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxController : MonoBehaviour
{
    public LetterPuzzleController lpc;

    // Each of the puzzle states
    public GameObject lockedBox;
    public GameObject openBox;
    public GameObject bookTaken;

    public ItemPickup book;

    // Start is called before the first frame update
    void Start()
    {
        if(lpc._correctCombination == true)
        {
            lockedBox.SetActive(false);
            openBox.SetActive(true);
        }
        if(book.item.pickedUp == true)   // IF book has been taken, disable open box and show the book taken 
        {
            openBox.SetActive(false);
            bookTaken.SetActive(true);
        }
    }


}
