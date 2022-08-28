using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClueSlotGroup : MonoBehaviour
{
    // Cache it so it doesn't have to call the instance every time
    ClueInventory clueInventory = ClueInventory.instance;

    public Transform cluesParent;

    public List<ClueSlot> presentSlots;
    public List<ClueSlot> pastSlots;

    public Enum.Location location;
    // public Enum.Timeline timeline;

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

        List<Clue> clues = clueInventory.clues.Where(x => x.location == location).Where(x => x.seen).ToList();
        Debug.Log(clues.Count);
        int presentSlotcount = 0;
        int pastSlotcount = 0;
        for (int i = 0; i < clues.Count; i++)
        {
            if(clues[i].timeline == Enum.Timeline.Present)
            {
                presentSlots[presentSlotcount].AddClue(clues[i]);
                presentSlotcount++;
            }
            else if(clues[i].timeline == Enum.Timeline.Past)
            {
                pastSlots[pastSlotcount].AddClue(clues[i]);
                pastSlotcount++;
            }
        }

        //for (int i = 0; i < slots.Count; i++)
        //{
        //    // Debug.Log(clueInventory.clues[i]);
        //    if (i < clueInventory.clues.Count)
        //    {
        //        // Debug.Log("Timeline inventory is: " + clueInventory.clues[i].timeline);
        //        // Debug.Log("Location inventory is: " + clueInventory.clues[i].location);
        //        // Debug.Log("Inventory count is: " + clueInventory.clues.Count);
        //        if (clueInventory.clues[i].timeline == timeline && clueInventory.clues[i].location == location)
        //        {
        //            Debug.Log("Adding Clue to: " + slots[i]);
        //            // This loop will add the item number 1 again since it doesn't skip
        //            for(int slotInt = 0; slotInt < slots.Count; slotInt++)
        //            {
        //                if(slots[slotInt].clue == null)
        //                {
        //                    Debug.Log("The clue being added to the UI is: " + clueInventory.clues[i]);
        //                    slots[slotInt].AddClue(clueInventory.clues[i]);
        //                    // So it doesn't add item to every single slot
        //                    break;
        //                }
        //                else if(slots[slotInt].clue == clueInventory.clues[i])
        //                {
        //                    Debug.Log("This is the same clue therefore break it");
        //                    break;
        //                }
        //            }
                    
        //        }
        //    }
        //    else
        //    {
        //        slots[i].ClearSlot();
        //    }
        //}
    }
}
