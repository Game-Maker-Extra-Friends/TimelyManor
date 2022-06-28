using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClueSystem : MonoBehaviour
{
    // To grab item stack more easily with item data
    public List<ClueData> clueData;
    public List<ClueItem> clueInventory;


    // Singleton ref
    public static ClueSystem currentClueSystem;

    private void Awake()
    {
        clueInventory = new List<ClueItem>();
        clueData = new List<ClueData>();
        currentClueSystem = this;

    }

    //public ClueItem Get(ClueData referenceData)
    //{
    //    if (clueData.TryGetValue(referenceData, out ClueItem value))
    //    {
    //        return value;
    //    }
    //    return null;
    //}


    // Add new item
    public void Add(ClueData referenceData)
    {
        // If item already exist, add to the stack, otherwise add a new instance


        Debug.Log("Add new Item");
        ClueItem newClue = new ClueItem(referenceData);
        clueInventory.Add(newClue);
        clueData.Add(referenceData);
        foreach (ClueItem ci in clueInventory)
        {
            Debug.Log("The Clue is: " + ci.data.id);
        }
 
        // Call this to let other know that inventory has changed.
        ClueChangeEvent();
    }

    //public void Remove(ClueData referenceData)
    //{
    //    // If item already exist, remove from the stack, otherwise remove the item from the inventory and the data in item dict.
    //    if (clueData.TryGetValue(referenceData, out ClueItem value))
    //    {
    //        value.RemoveFromStack();
    //        if (value.stackSize == 0)
    //        {
    //            clueInventory.Remove(value);
    //            clueData.Remove(referenceData);
    //        }
    //    }
    //    ClueChangeEvent();
    //}






    //Event System Test


    // Action for when Inventory Changes
    public event Action onClueChangeEvent;


    // Add and remove calls this to let others who listen in to know that inventory has changed.
    public void ClueChangeEvent()
    {
        if (onClueChangeEvent != null)
        {
            onClueChangeEvent();
        }
    }

}
