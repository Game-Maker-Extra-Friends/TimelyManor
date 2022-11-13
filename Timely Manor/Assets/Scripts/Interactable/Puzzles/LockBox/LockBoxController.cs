using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxController : MonoBehaviour
{
    public LetterPuzzleController lpc;
    public static LockBoxController instance;

    // Each of the puzzle states
    public GameObject lockedBox;
    public GameObject openBox;
    public GameObject bookTaken;

    public ItemPickup book;
    public bool pickedUpAndUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (ES3.KeyExists(gameObject.name + "pickedUpAndUsed", "Saves/LockedBox.es3"))
        {
            pickedUpAndUsed = ES3.Load<bool>(gameObject.name + "pickedUpAndUsed", "Saves/LockedBox.es3");
        }
        UpdateBox();
    }

    public void UpdateBox()
    {
        if ((lpc._correctCombination == true || book.item.pickedUp == true) && pickedUpAndUsed == false)
        {
            lockedBox.SetActive(false);
            openBox.SetActive(true);
        }
        if (book.item.pickedUp == true || pickedUpAndUsed == true)   // IF book has been taken, disable open box and show the book taken 
        {
            openBox.SetActive(false);
            bookTaken.SetActive(true);
            pickedUpAndUsed = true;
        }
        ES3.Save(gameObject.name + "pickedUpAndUsed", pickedUpAndUsed, "Saves/LockedBox.es3");

    }

}
