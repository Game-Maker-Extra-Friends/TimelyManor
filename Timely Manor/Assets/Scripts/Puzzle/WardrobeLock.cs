using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeLock : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite open;
    public Sprite bookGone;
    public Item item;

    public void Start()
    {
        Debug.Log("The Item is: " + item.name + " And the pickedUp bool is: " + item.pickedUp);
        if (item.pickedUp == true)
        {
            Debug.Log("Yellow Book Taken");
            TakeBook();
        }
    }

    public void OpenBox()
    {
        render.sprite = open;
    }

    public void TakeBook()
    {
        render.sprite = bookGone;
    }
}
