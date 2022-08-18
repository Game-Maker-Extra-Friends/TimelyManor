using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    private Save save;

    public int space = 20;

    public List<Item> items;

    private void Start()
    {
        items = Resources.LoadAll<Item>("Items").ToList();
        onItemCalledback?.Invoke(); // Invote update when laod stuff
    }

    // return bool, if inventory is full return false so the Item doesn't get destroyed.
    public bool Add(Item item)
    {

        if(items.Count >= space)
        {
            Debug.Log("BUG - We screwed up and somehow don't have enough room");
            return false;
        }

        item.pickedUp = true;

        // Call the delgate to let other method who subscribes to it know.
        onItemCalledback?.Invoke();


        return true;
    }

    public void Remove(Item item)
    {
        item.pickedUp = false;
        items.Remove(item);
    }

}
