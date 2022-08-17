using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueInventoryUI : MonoBehaviour
{

    public Transform cluesParent;

    public List<ClueSlotGroup> slotsGroup;

    void Awake()
    {
        // Update UI everytime item is added or removed.
        ClueInventory.instance.onClueCalledback += UpdateUI;

            
        for(int i = 0; i < cluesParent.childCount - 1; i++)
        {
            slotsGroup.Add(cluesParent.GetChild(i).GetComponent<ClueSlotGroup>());
        }
    }


    void UpdateUI()
    {
        for (int i = 0; i < slotsGroup.Count; i++)
        {
            //Debug.Log("Calling Slot Group: " + slotsGroup[i]);
            slotsGroup[i].UpdateUI();
        }
        List<Clue> clues = ClueInventory.instance.clues;   
        // Additem to slots or clear them if there's nothing.
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < clues.Count)
            {
                Debug.Log("Inventory count is: " + clues.Count);
                slots[i].AddClue(clues[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
