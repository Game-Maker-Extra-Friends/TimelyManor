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
        if (ES3.KeyExists(item.name, "Saves/ItemSaves.es3"))
        {
            item.pickedUp = ES3.Load<bool>(item.name, "Saves/ItemSaves.es3");
            Debug.Log("Save exists");
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
            ES3.Save(item.name, item.pickedUp, "Saves/ItemSaves.es3");
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        //Resources.Load<Save>("Saves/Save").SaveItemState(item.name, item.pickedUp);
    }

    private void OnDestroy()
    {
        //Resources.Load<Save>("Saves/Save").SaveItemState(item.name, item.pickedUp);
    }
}
