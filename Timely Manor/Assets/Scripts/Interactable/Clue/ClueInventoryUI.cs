using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ClueInventoryUI : MonoBehaviour
{

    public Transform cluesParent;

    public List<ClueSlotGroup> slotsGroup;

    void Start()
    {
        // Update UI everytime item is added or removed.
        ClueInventory.instance.onClueCalledback += UpdateUI;

            
        for(int i = 0; i < cluesParent.childCount - 1; i++)
        {
            slotsGroup.Add(cluesParent.GetChild(i).GetComponent<ClueSlotGroup>());
        }
        UpdateUI(); // For first update in case the player loads.
    }


    void UpdateUI()
    {
        for (int i = 0; i < slotsGroup.Count; i++)
        {
            //Debug.Log("Calling Slot Group: " + slotsGroup[i]);
            slotsGroup[i].UpdateUI();
        }
    }
}
