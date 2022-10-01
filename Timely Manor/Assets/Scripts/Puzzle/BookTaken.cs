using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTaken : MonoBehaviour
{
    public WoodenBoxScript box;

    private void Start()
    {
        box = FindObjectOfType<WoodenBoxScript>();
    }

    // So The Sprite outside the UI shows the book being taken
    public void BookTakenTrue()
    {
        box.TakeBook();
    }
}
