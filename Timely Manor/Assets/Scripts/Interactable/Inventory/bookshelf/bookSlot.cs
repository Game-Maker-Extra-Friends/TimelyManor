using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookSlot : ItemInteract
{

    public Item book;

    public string blueBookName, redBookName, yellowBookName;

    public Sprite bookSprite;

    public override void Interact(Item item)
    {
        if (book == null)
        {
            if (item.name == blueBookName || item.name == redBookName || item.name == yellowBookName)
            {
                book = item;
            }
        }
        else
        {
            Inventory.instance.Add(book);
            book = null;
        }
    }

    public bool check()
    {
        if (book.name == reqItem)
        {
            return true;
        }
        return false;
    }

    public string getColor()
    {
        if (book.name == blueBookName)
            return "blue";

        if (book.name == redBookName)
            return "red";

        if (book.name == yellowBookName)
            return "yellow";

        return null;
    }

}
