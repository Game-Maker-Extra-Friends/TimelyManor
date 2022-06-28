using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject m_slotPrefabs;

    [SerializeField]
    GameObject[] m_slotGameObject;

    [SerializeField]
    JournalMenu _journalMenu;

    [SerializeField]
    private SlotManagement[] m_slots;


    // Have to be awake since its deactivaed at the beginning
    private void Awake()
    {
        _journalMenu.onJournalOpenEvent += OnOpenJournal;

        _journalMenu.onJournalCloseEvent += OnCloseJournal;

        int slotLength = m_slotGameObject.Length;
        m_slots = new SlotManagement[slotLength];

        int i = 0;
        foreach (GameObject o in m_slotGameObject)
        {
            Debug.Log(i);
            m_slots[i] = o.transform.GetComponent<SlotManagement>();
            i++;
        }
    }

    private void OnCloseJournal()
    {
        // Delete Slots here.
        foreach (SlotManagement sm in m_slots)
        {
            sm.DespawnSlot();
        }
    }

    private void OnOpenJournal()
    {
        // Redundant but just in case
        foreach (SlotManagement sm in m_slots)
        {
            sm.DespawnSlot();
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.currentInventory.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        Debug.Log("Inventory Menu Added item");
        GameObject obj = Instantiate(m_slotPrefabs);

        // Add the slot into an empty slot
        foreach (GameObject o in m_slotGameObject)
        {
            if (o.transform.childCount == 0)
            {
                // Call spawn script here
                obj.transform.SetParent(o.transform, false);
                break;
            }
        }

        

        InventorySlot slot = obj.GetComponent<InventorySlot>();
        slot.Set(item);
    }
}
