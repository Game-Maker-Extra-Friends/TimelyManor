using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public void Start()
    {
        // Check if interacted save exists, if it does then load the bool which will destroy the gameobject.
        if (ES3.KeyExists(interactedID))
        {
            interacted = ES3.Load<bool>(interactedID, "Saves/");
            Debug.Log("Save exists");
        }


        if(interacted == true)
        {
            Destroy(gameObject);
        }
        interactbleType = "Item";
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

        // If item is picked up then destroy the gameobject + save the fact that it has been picked up so changing timeline 
        if (wasPickedUp)
            interacted = true;
            ES3.Save(interactedID, interacted, "Saves/ItemSaves.es3");
            Destroy(gameObject);
    }
}
