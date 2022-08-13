using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueInventoryUI : MonoBehaviour
{
    // Cache it so it doesn't have to call the instance every time
    ClueInventory clueInventory;

    public Transform cluesParent;

    public List<ClueSlotGroup> slotsGroup;

    void Start()
    {
        clueInventory = ClueInventory.instance;

        Debug.Log(clueInventory);
        // Update UI everytime item is added or removed.
        clueInventory.onClueCalledback += UpdateUI;

            
        for(int i = 0; i < cluesParent.childCount - 1; i++)
        {
            slotsGroup.Add(cluesParent.GetChild(i).GetComponent<ClueSlotGroup>());
        }
    }


    void UpdateUI()
    {
        for (int i = 0; i < slotsGroup.Count; i++)
        {
            Debug.Log("Calling Slot Group: " + slotsGroup[i]);
            slotsGroup[i].UpdateUI();
        }
    }
}
