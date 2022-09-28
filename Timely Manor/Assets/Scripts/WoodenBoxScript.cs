using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoxScript : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite open;
    public Sprite bookGone;

    public void Start()
    {
        if (Inventory.instance.GetItem("Blue Leather Book") != null)
        {
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
