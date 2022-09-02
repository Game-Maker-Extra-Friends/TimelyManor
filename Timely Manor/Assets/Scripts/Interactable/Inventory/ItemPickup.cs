using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void Start()
    {
        if (item.pickedUp)
        {
            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        Debug.Log("Picking up: " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        // If item is picked up then destroy the gameobject + save the fact that it has been picked up so changing timeline 
        if (wasPickedUp)
        {
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
