using UnityEngine;
using StarterAssets;

public class InventoryUI : MonoBehaviour
{
    
    public static InventoryUI instance;
    // Cache it so it doesn't have to call the instance every time
    Inventory inventory;

    public Transform itemsParent;
    public Transform inventoryBar;

    InventorySlot[] slots;

    [SerializeField]
    GameObject m_slotPrefab;

    void Start()
    {
        inventory = Inventory.instance;

        // Update UI everytime item is added or removed.
        inventory.onItemCalledback += OnUpdateInventory;
        inventory.onItemCalledback += UpdateUI;

        instance = this;

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

	public void OnUpdateInventory()
	{
        HideInventory();
		DrawInventory();
	}

	public void DrawInventory()
	{
		foreach (Item item in Inventory.instance.items)
		{
            if (item.pickedUp)
    			AddInventorySlot(item);
		}
	}

    public void HideInventory()
    {
        foreach (Transform t in inventoryBar)
        {
            Destroy(t.gameObject);
        }
    }

	public void AddInventorySlot(Item item)
	{
		// Instantiate Item slot prefab
		GameObject obj = Instantiate(m_slotPrefab);
        
		// Set parent as which a layout group
		obj.transform.SetParent(inventoryBar, false);

		ItemSlot slot = obj.GetComponent<ItemSlot>();
		slot.Set(item);
	}

}
