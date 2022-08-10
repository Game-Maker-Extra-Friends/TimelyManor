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
            DestroyImmediate(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemCalledback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    private void Start()
    {
        if (ES3.KeyExists("InventoryItems", "Saves/InventoryItems.es3"))
        {
            items = ES3.Load<List<Item>>("InventoryItems", "Saves/InventoryItems.es3");
            if (onItemCalledback != null)
                onItemCalledback.Invoke(); // Invote update when laod stuff
        }
    }


    // return bool, if inventory is full return false so the Item doesn't get destroyed.
    public bool Add(Item item)
    {

        if(items.Count >= space)
        {
            Debug.Log("BUG - We screwed up and somehow don't have enough room");
            return false;
        }

        items.Add(item);

        ES3.Save("InventoryItems", items, "Saves/InventoryItems.es3");

        // Call the delgate to let other method who subscribes to it know.
        if(onItemCalledback != null)
            onItemCalledback.Invoke();


        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        ES3.Save("InventoryItems", items, "Saves/InventoryItems.es3");
    }

}
