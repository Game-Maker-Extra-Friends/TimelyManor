using UnityEngine;

public class ClueInventoryUI : MonoBehaviour
{
    // Cache it so it doesn't have to call the instance every time
    ClueInventory clueInventory;

    public Transform cluesParent;

    ClueSlotGroup[] slotsGroup;


    void Start()
    {
        clueInventory = ClueInventory.instance;

        Debug.Log(clueInventory);
        // Update UI everytime item is added or removed.
        clueInventory.onClueCalledback += UpdateUI;


        slotsGroup = cluesParent.GetComponentsInChildren<ClueSlotGroup>();
    }


    void UpdateUI()
    {
        for (int i = 0; i < slotsGroup.Length; i++)
        {
            slotsGroup[i].UpdateUI();
        }
    }
}
