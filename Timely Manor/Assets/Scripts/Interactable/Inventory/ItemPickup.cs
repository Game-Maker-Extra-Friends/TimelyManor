using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemPickup : Interactable
{
    public Item item;

    public void Start()
    {
        if (item.pickedUp)
        {
            Destroy(gameObject);
        }

        // Set interactable type to item if people forget to set it to item in inspector
        interactbleType = InteractbleType.Item;
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
        {
            interacted = true;
            item.pickedUp = true;
            Destroy(gameObject);
        }
            
    }

    private void OnApplicationQuit()
    {
        Resources.Load<Save>("Saves/Save").SaveItemState(item.name, item.pickedUp);
    }

    private void OnDestroy()
    {
        Resources.Load<Save>("Saves/Save").SaveItemState(item.name, item.pickedUp);
    }
}
