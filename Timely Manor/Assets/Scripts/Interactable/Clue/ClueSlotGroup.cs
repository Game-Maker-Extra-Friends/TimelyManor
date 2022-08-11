using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSlotGroup : MonoBehaviour
{
    // Cache it so it doesn't have to call the instance every time
    ClueInventory clueInventory;

    public Transform cluesParent;

    ClueSlot[] slots;

    public Enum.Location location;
    public Enum.Timeline timeline;


    void Start()
    {
        clueInventory = ClueInventory.instance;

        // Debug.Log(clueInventory);
        // Update UI everytime item is added or removed.
        clueInventory.onClueCalledback += UpdateUI;


        slots = cluesParent.GetComponentsInChildren<ClueSlot>();
    }


    public void UpdateUI()
    {
        // Additem to slots or clear them if there's nothing.
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < clueInventory.clues.Count)
            {
                // Debug.Log("Inventory count is: " + clueInventory.clues.Count);
                if(clueInventory.clues[i].timeline == timeline && clueInventory.clues[i].location == location)
                {
                    slots[i].AddClue(clueInventory.clues[i]);
                }
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
