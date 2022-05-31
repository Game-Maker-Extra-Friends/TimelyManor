using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        // Singleton reference, call Add function and add the item
        InventorySystem.current.Add(referenceItem);
        Debug.Log(referenceItem.icon);
        Destroy(gameObject);
        Debug.Log("DestroyItem");
    }
}
