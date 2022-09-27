using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookSlot : ItemInteract
{

    public Item book;

    private string blueBookName = "Blue Leather Bound Book", redBookName = "Red Leather Bound Book", yellowBookName = "Yellow Leather Bound Book";

    private SpriteRenderer bookSprite;

    private bookshelfInteraction bookshelf;

    private void Start()
    {
        bookSprite = gameObject.GetComponent<SpriteRenderer>();
        bookshelf = transform.GetComponentInParent<bookshelfInteraction>();
    }

    public void Interact()
    {
        Debug.Log("interact()");
        if (book != null)
        {
            Inventory.instance.Add(book);
            book = null;
            
            bookshelf.updateSprites();
        }
    }

    public override void useItem(Item item = null)
    {
        Debug.Log("interact(item)");
        if (book == null)
        {
            if (item.name == blueBookName || item.name == redBookName || item.name == yellowBookName)
            {
                book = item;
                Inventory.instance.Remove(item);

                bookshelf.updateSprites();
            }
            
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

    public void setSprite(Sprite sprite)
    {
        bookSprite.sprite = sprite;
    }
}
