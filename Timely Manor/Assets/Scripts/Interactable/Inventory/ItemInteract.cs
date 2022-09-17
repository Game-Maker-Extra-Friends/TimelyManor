using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    public string reqItem;

    // Start is called before the first frame update
    public void Interact(Item item)
    {
        if (item.name == reqItem)
        {
            // Do Stuff

            Inventory.instance.Remove(item);
        }
    }
}
