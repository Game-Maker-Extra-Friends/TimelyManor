using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;

    public Image detailsIcon;
    public TextMeshProUGUI detailsText;


    public void AddItem(Item newItem)
    {
        item = newItem;

        Debug.Log("The added item is: " + item);
        Debug.Log("The added icon is: " + item.icon);

        icon.enabled = true;
        icon.sprite = item.icon;
        //Debug.Log("The icon is added");
        
    } 

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void DisplayDescription()
    {
        // The item des go into the next page
        if(item != null)
        {
            detailsIcon.sprite = item.icon;
            detailsText.text = item.description;
        }
    }

}
