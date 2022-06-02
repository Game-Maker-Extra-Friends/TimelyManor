using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueMenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject m_slotPrefabs;

    [SerializeField]
    GameObject[] m_slotGameObject;

    [SerializeField]
    JournalMenu _journalMenu;

    [SerializeField]
    private ClueSlotManagement[] m_clueSlots;


    // Have to be awake since its deactivaed at the beginning
    private void Awake()
    {
        _journalMenu.onJournalOpenEventClue += OnOpenJournal;

        _journalMenu.onJournalCloseEvent += OnCloseJournal;

        int slotLength = m_slotGameObject.Length;
        m_clueSlots = new ClueSlotManagement[slotLength];

        int i = 0;
        foreach (GameObject o in m_slotGameObject)
        {
            Debug.Log(i);
            m_clueSlots[i] = o.transform.GetComponent<ClueSlotManagement>();
            i++;
        }
    }

    private void OnCloseJournal()
    {
        // Delete Slots here.
        foreach (ClueSlotManagement cm in m_clueSlots)
        {
            cm.DespawnSlot();
        }
    }

    private void OnOpenJournal()
    {
        // Redundant but just in case
        foreach (ClueSlotManagement cm in m_clueSlots)
        {
            cm.DespawnSlot();
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (ClueItem item in ClueSystem.currentClueSystem.clueInventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(ClueItem item)
    {
        Debug.Log("Clue Menu Added item");
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



        ClueSlot slot = obj.GetComponent<ClueSlot>();
        slot.Set(item);
    }
}
