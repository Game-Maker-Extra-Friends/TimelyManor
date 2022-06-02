using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClueSystem : MonoBehaviour
{
    // To grab item stack more easily with item data
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    //public InventorySystem current;

    // Singleton ref
    public static ClueSystem current;

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        current = this;

    }

    private void Start()
    {
        //EventSystem.current.onInventoryAddEvent += Add();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }


    // Add new item
    public void Add(InventoryItemData referenceData)
    {
        // If item already exist, add to the stack, otherwise add a new instance
        Debug.Log("Add called");
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Add new Item");
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }

        // Call this to let other know that inventory has changed.
        InventoryChangeEvent();
    }

    public void Remove(InventoryItemData referenceData)
    {
        // If item already exist, remove from the stack, otherwise remove the item from the inventory and the data in item dict.
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
        InventoryChangeEvent();
    }






    //Event System Test


    // Action for when Inventory Changes
    public event Action onInventoryChangeEvent;


    // Add and remove calls this to let others who listen in to know that inventory has changed.
    public void InventoryChangeEvent()
    {
        if (onInventoryChangeEvent != null)
        {
            onInventoryChangeEvent();
        }
    }

}
