using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookshelfInteraction : MonoBehaviour
{

    public float slideAmount = 1.9f;

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
        Debug.Log("open()");

        // Kick player out of interaction
        StarterAssets.FirstPersonController.instance.ExitAction.Enable();

        GameObject g = this.gameObject.transform.GetChild(0).gameObject;

        g.SetActive(false);

        StartCoroutine(DoSlidingOpen());
        // Slide bookcase when books placed correctly
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPos = transform.position + slideAmount * Vector3.back;
        Vector3 startPos = transform.position;

        float time = 0;

        while (time < 1)
        {
            Debug.Log(time);
            transform.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
            time += Time.deltaTime * 1f;
        }
    }

    public void updateSprites()
    {
        updateSlotSprite(left);
        updateSlotSprite(middle);
        updateSlotSprite(right);
    }

    private void updateSlotSprite(bookSlot slot)
    {
        if (slot.book == null)
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
