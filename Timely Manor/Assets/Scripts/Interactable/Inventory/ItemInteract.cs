using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{

    // String that matches the name of the item required to interact with this
    public string reqItem;

    // Sprites, clues, etc that will be revealed after this is interacted with
    public GameObject[] toEnable;

    // Sprites, clues, etc that will be hidden after this is interacted with
    public GameObject[] toDisable;

    bool interacted = false;

    private void Start()
    {
        if (ES3.KeyExists(gameObject.name + "Enabled", "Saves/Safe.es3"))
        {
            foreach (GameObject obj in toDisable)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in toEnable)
            {
                obj.SetActive(true);
            }
        }
    }

    public virtual void useItem(Item item)
    {
        if (item.name == reqItem)
        {
            foreach (GameObject obj in toDisable)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in toEnable)
            {
                obj.SetActive(true);
                interacted = true;
                ES3.Save(gameObject.name + "Enabled", interacted, "Saves/Safe.es3");
            }

            Inventory.instance.Remove(item);
        }
    }

 
}