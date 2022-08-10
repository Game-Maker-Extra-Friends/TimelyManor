using UnityEngine;
using System.Collections.Generic;
public class ClueInventoryUI : MonoBehaviour
{

    public Transform cluesParent;

    ClueSlot[] slots;


    void Start()
    {
        // Update UI everytime item is added or removed.
        ClueInventory.instance.onClueCalledback += UpdateUI;


        slots = cluesParent.GetComponentsInChildren<ClueSlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void UpdateUI()
    {
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
