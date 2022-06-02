using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSlotManagement : MonoBehaviour
{
    [SerializeField]
    GameObject m_slotPrefabs;

    [SerializeField]
    GameObject[] m_slotGameObject;


    public void SpawnSlot(InventoryItem item)
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


    public void DespawnSlot()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Destroying: " + child);
            Destroy(child.gameObject);
        }
    }
}
