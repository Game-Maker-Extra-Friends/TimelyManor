using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public void Start()
    {
        if(ES3.KeyExists(pickedUpID))
            pickedUp = ES3.Load<bool>(pickedUpID);   

        if(pickedUp == true)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up: " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        // If item is picked up then destroy the gameobject
        if (wasPickedUp)
            pickedUp = true;
            ES3.Save(pickedUpID, pickedUp);
            Destroy(gameObject);
    }
}
