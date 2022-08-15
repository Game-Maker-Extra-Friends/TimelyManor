using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSlotGroup : MonoBehaviour
{
    // Cache it so it doesn't have to call the instance every time
    ClueInventory clueInventory = ClueInventory.instance;

    public Transform cluesParent;

    public List<ClueSlot> slots;

    public Enum.Location location;
    public Enum.Timeline timeline;

    private bool run = true;



    void Start()
    {
        clueInventory = ClueInventory.instance;

        // Doesn't work since gameObject is inactive
        //foreach (Transform child in transform)
        //{
        //    slots.Add(child.GetComponent<ClueSlot>());
        //}
    }


    public void UpdateUI()
    {
        clueInventory = ClueInventory.instance;
        //Debug.Log("The slot count is: " + slots.Count);
        //Debug.Log("Singleton count is: " + clueInventory.clues.Count);
        // Additem to slots or clear them if there's nothing.
        for (int i = 0; i < slots.Count; i++)
        {
            Debug.Log(clueInventory.clues[i]);
            if (i < clueInventory.clues.Count)
            {
                // Debug.Log("Timeline inventory is: " + clueInventory.clues[i].timeline);
                // Debug.Log("Location inventory is: " + clueInventory.clues[i].location);
                // Debug.Log("Inventory count is: " + clueInventory.clues.Count);
                if (clueInventory.clues[i].timeline == timeline && clueInventory.clues[i].location == location)
                {
                    Debug.Log("Adding Clue to: " + slots[i]);
                    for(int slotInt = 0; slotInt < slots.Count; slotInt++)
                    {
                        if(slots[slotInt].clue == null)
                        {
                            Debug.Log("The clue being added to the UI is: " + clueInventory.clues[i]);
                            slots[slotInt].AddClue(clueInventory.clues[i]);
                            // So it doesn't add item to every single slot
                            break;
                        }
                    }
                    
                }
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
