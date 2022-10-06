using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoxScript : MonoBehaviour
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
            Debug.Log("Blue Book Taken");
            TakeBook();
        }
        if (ES3.KeyExists(gameObject.name + "OpenState", "Saves/CombinationPuzzle.es3"))
        {
            OpenBox();
            if (ES3.KeyExists(gameObject.name + "TakenState", "Saves/CombinationPuzzle.es3"))
            {
                Debug.Log("Wooden Box Script Taking Book");
                TakeBook();
            }

        }
    }
    public void Update()
    {
        if (ES3.KeyExists(gameObject.name + "TakenState", "Saves/CombinationPuzzle.es3"))
        {
            TakeBook();
        }
        else if (ES3.KeyExists(gameObject.name + "OpenState", "Saves/CombinationPuzzle.es3"))
        {
            OpenBox();
            

        }
    }

    public void OpenBox()
    {
        render.sprite = open;
        ES3.Save(gameObject.name + "OpenState", render.sprite, "Saves/CombinationPuzzle.es3");
    }

    public void TakeBook()
    {
        render.sprite = bookGone;
        ES3.Save(gameObject.name + "TakenState", render.sprite, "Saves/CombinationPuzzle.es3");
    }
}
