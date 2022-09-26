using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookSlot : ItemInteract
{

    public Item book;

    private string blueBookName = "Blue Leather Bound Book", redBookName = "Red Leather Bound Book", yellowBookName = "Yellow Leather Bound Book";

    private SpriteRenderer bookSprite;

    private void Start()
    {
        bookSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Interact(Item item = null)
    {
        Debug.Log(item);
        if (book == null)
        {
            if (item.name == blueBookName || item.name == redBookName || item.name == yellowBookName)
            {
                book = item;
                bookshelfInteraction.instance.updateSprites();

                Inventory.instance.Remove(item);
            }
        }
    }

    public void Interact()
    {
        Debug.Log(book);
        Inventory.instance.Add(book);
        book = null;
        bookshelfInteraction.instance.updateSprites();
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

    public void setSprite(Sprite sprite)
    {
        bookSprite.sprite = sprite;
    }
}
