using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookshelfInteraction : MonoBehaviour
{

    public static bookshelfInteraction instance;

    [Header("Book Slot Gameobjects")]
    public bookSlot left, middle, right;

    [Header("Book Sprites")]
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
            slot.setSprite(null);
            return;
        }

        switch (slot.getColor())
        {
            case "blue":
                slot.setSprite(blue);
                break;
            case "red":
                slot.setSprite(red);
                break;
            case "yellow":
                slot.setSprite(yellow);
                break;
            default:
                break;
        }
    }
}
