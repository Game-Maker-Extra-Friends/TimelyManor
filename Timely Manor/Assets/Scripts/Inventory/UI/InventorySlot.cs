using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image m_icon;

    [SerializeField]
    private Image m_largeIcon;

    [SerializeField]
    private TextMeshProUGUI m_label;

    [SerializeField]
    private GameObject m_stackObj;

    [SerializeField]
    private TextMeshProUGUI m_stackLabel;

    [SerializeField]
    private TextMeshProUGUI m_description;

    public void Set(InventoryItem item)
    {
        // Set the image to the icon set in Inventory Item
        Debug.Log("Inventory Slot Called");
        m_icon.sprite = item.data.icon;

        // Set text to Display name
        m_label.text = item.data.displayName;

        if (m_description)
        {
            // Set description
            m_description.text = item.data.description;
        }

        // If there are less than 1 stack, turn off the count
        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_stackLabel.text = item.stackSize.ToString();
    }
}
