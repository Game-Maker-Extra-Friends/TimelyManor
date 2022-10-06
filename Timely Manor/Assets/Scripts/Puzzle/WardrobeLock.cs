using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeLock : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite open;
    public Sprite bookGone;
    public Item item;

    private bool OpenedBox = false;
    private bool TakenBook = false;

    public void Start()
    {
        Debug.Log("The Item is: " + item.name + " And the pickedUp bool is: " + item.pickedUp);
        if (item.pickedUp == true)
        {
            Debug.Log("Yellow Book Taken");
            TakeBook();
        }
        if (ES3.KeyExists(gameObject.name + "TakenState", "Saves/CombinationPuzzle.es3"))
        {
            render.sprite = ES3.Load<Sprite>(gameObject.name + "TakenState", "Saves/CombinationPuzzle.es3");
        }

    }
    public void Update()
    {
        
        //else if (ES3.KeyExists(gameObject.name + "OpenState", "Saves/CombinationPuzzle.es3"))
        //{
        //    OpenBox();
        //}
    }

    public void OpenBox()
    {
        render.sprite = open;
        OpenedBox = true;
        ES3.Save(gameObject.name + "OpenState", OpenedBox, "Saves/CombinationPuzzle.es3");
    }

    public void TakeBook()
    {
        render.sprite = bookGone;
        TakenBook = true;
        ES3.Save(gameObject.name + "TakenState", render.sprite, "Saves/CombinationPuzzle.es3");
    }
}
