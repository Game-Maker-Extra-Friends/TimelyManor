using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Cache it so it doesn't have to call the instance every time
    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;


    void Start()
    {
        inventory = Inventory.instance;

        // Update UI everytime item is added or removed.
        inventory.onItemCalledback += UpdateUI;


        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }



    void UpdateUI()
    {
        // Additem to slots or clear them if there's nothing.
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                Debug.Log("Inventory count is: " + inventory.items.Count);
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
