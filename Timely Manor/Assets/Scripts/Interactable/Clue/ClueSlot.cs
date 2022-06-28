using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ClueSlot : MonoBehaviour
{
    Clue clue;
    public Image icon;

    public Image detailsIcon;
    public TextMeshProUGUI detailsText;


    public void AddClue(Clue newClue)
    {
        clue = newClue;

        Debug.Log("The added item is: " + clue);
        Debug.Log("The added icon is: " + clue.icon);

        icon.enabled = true;
        icon.sprite = clue.icon;
        //Debug.Log("The icon is added");

    }

    public void ClearSlot()
    {
        clue = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void DisplayDescription()
    {
        // The item des go into the next page
        if (clue != null)
        {
            detailsIcon.sprite = clue.icon;
            detailsText.text = clue.description;
        }
    }
}
