using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        // Singleton reference, call Add function and add the item
        Debug.Log(referenceItem.icon);
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
        Debug.Log("DestroyItem");
    }
}
