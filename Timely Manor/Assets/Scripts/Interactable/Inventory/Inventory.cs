using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    // Shared by all instance of a class
    public static Inventory instance;

    private void Awake()
    {
        // makes the instace = to this component, anyone can now access this so this is now a singleton.
        if(instance != null)
        {
            Debug.Log("more than one instance of inventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemCalledback;

    public int space = 20;

    public List<Item> items = new List<Item>();


    // return bool, if inventory is full return false so the Item doesn't get destroyed.
    public bool Add(Item item)
    {

        if(items.Count >= space)
        {
            Debug.Log("BUG - We screwed up and somehow don't have enough room");
            return false;
        }

        items.Add(item);

        // Call the delgate to let other method who subscribes to it know.
        if(onItemCalledback != null)
            onItemCalledback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}