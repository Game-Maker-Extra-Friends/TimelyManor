using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookSlot : ItemInteract
{

    public Item book;

    private string blueBookName = "Blue Leather Bound Book", redBookName = "Red Leather Bound Book", yellowBookName = "Yellow Leather Bound Book";

    public SpriteRenderer bookSprite;

    private bookshelfInteraction bookshelf;

    private void Start()
    {
        bookSprite = gameObject.GetComponent<SpriteRenderer>();
        bookshelf = transform.GetComponentInParent<bookshelfInteraction>();
        if (ES3.KeyExists(gameObject.name + "Book", "Saves/BookshelfPuzzle.es3"))
        {
            Item tempBook = ES3.Load<Item>(gameObject.name + "Book", "Saves/BookshelfPuzzle.es3");
            if(tempBook != null)
            {
                useItemFromSave(tempBook);
            }
            
        }

    }

    public void Interact()
    {
        //Debug.Log("interact()");
        //if (book != null)
        //{
        //    Inventory.instance.Add(book);
        //    book = null;
            
        //    bookshelf.updateSprites();
        //}
    }

    public override void useItem(Item item = null)
    {
        Debug.Log("interact(item)");
        if (book == null)
        {
            //if (item.name == blueBookName || item.name == redBookName || item.name == yellowBookName)
            if (item.name == reqItem)
            {
                book = item;
                Inventory.instance.Remove(item);

                bookshelf.updateSprites(gameObject.name);

                bookshelf.check();
            }
            
        }
        ES3.Save(gameObject.name + "Book", book, "Saves/BookshelfPuzzle.es3");
    }
    public void useItemFromSave(Item item)
    {
        book = item;

        bookshelf.updateSprites(gameObject.name);

        bookshelf.check();

        ES3.Save(gameObject.name + "Book", book, "Saves/BookshelfPuzzle.es3");
    }

    public bool check()
    {
        if (book == null) return false;
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
        Debug.Log("The Book Sprite is: " + bookSprite.name + " The Sprite is: " + sprite);
        bookSprite.sprite = sprite;
    }
}
