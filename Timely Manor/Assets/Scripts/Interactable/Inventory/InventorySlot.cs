using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public RawImage icon;

    public RawImage detailsIcon;
    public TextMeshProUGUI detailsText;


    public void AddItem(Item newItem)
    {
        item = newItem;
        
        Debug.Log("The added item is: " + item);
        Debug.Log("The added icon is: " + item.icon);

        icon.enabled = true;
        icon.texture = item.icon;
        Debug.Log("The icon is added");
        
    } 

    public void ClearSlot()
    {
        item = null;
        // icon.enabled = false;
    }

    public void DisplayDescription()
    {
        // The item des go into the next page
        if(item != null)
        {
            detailsIcon.texture = item.icon;
            detailsText.text = item.description;
        }
    }

}
