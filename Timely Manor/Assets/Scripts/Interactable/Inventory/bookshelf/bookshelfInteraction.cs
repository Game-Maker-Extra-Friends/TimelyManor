using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookshelfInteraction : MonoBehaviour
{

    public bookshelfInteraction instance;

    public bookSlot left, middle, right;

    public Sprite blue, red, yellow;

    public void check()
    {
        if (left.check() && middle.check() && right.check())
        {
            open();
        }
    }

    private void open()
    {
        // Slide bookcase when books placed correctly
    }

    public void updateSprites()
    {
        updateSlotSprite(left);
        updateSlotSprite(middle);
        updateSlotSprite(right);
    }

    private void updateSlotSprite(bookSlot slot)
    {
        if (slot == null)
        {
            slot.bookSprite = null;
            return;
        }

        switch (slot.getColor())
        {
            case "blue":
                slot.bookSprite = blue;
                break;
            case "red":
                slot.bookSprite = red;
                break;
            case "yellow":
                slot.bookSprite = yellow;
                break;
            default:
                break;
        }
    }
}
