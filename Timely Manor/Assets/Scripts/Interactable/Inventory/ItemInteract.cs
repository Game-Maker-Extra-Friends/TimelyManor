using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{

    // String that matches the name of the item required to interact with this
    public string reqItem;

    // Sprites, clues, etc that will be revealed after this is interacted with
    public GameObject[] toEnable;

    // Sprites, clues, etc that will be hidden after this is interacted with
    public GameObject[] toDisable;

    // Start is called before the first frame update
    public void Interact(Item item)
    {
        if (item.name == reqItem)
        {
            Action();

            Inventory.instance.Remove(item);
        }
    }

    public virtual void Action()
    {
        foreach (GameObject obj in toDisable)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in toEnable)
        {
            obj.SetActive(true);
        }
    }
}