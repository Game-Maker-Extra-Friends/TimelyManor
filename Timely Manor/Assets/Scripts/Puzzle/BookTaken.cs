using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTaken : MonoBehaviour
{
    public WoodenBoxScript box;
    public WardrobeLock wardrobe;

    public bool forWoodenBox;
    public bool forWardrobe;

    private void Start()
    {
        if (forWoodenBox)
        {
            box = FindObjectOfType<WoodenBoxScript>();
        }
        else
        {
            wardrobe = FindObjectOfType<WardrobeLock>();
        }
    }

    // So The Sprite outside the UI shows the book being taken
    public void BookTakenTrue()
    {
        if (forWoodenBox)
        {
            box.TakeBook();
        }
        else
        {
            wardrobe.TakeBook();
        }
    }
}
