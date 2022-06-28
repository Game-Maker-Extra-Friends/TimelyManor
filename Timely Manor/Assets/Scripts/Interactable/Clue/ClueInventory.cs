using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInventory : MonoBehaviour
{
    #region Singleton
    // Shared by all instance of a class
    public static ClueInventory instance;

    private void Awake()
    {
        Debug.Log("Clue Instance set");
        // makes the instace = to this component, anyone can now access this so this is now a singleton.
        if (instance != null)
        {
            Debug.Log("more than one instance of clueInventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnClueChanged();
    public OnClueChanged onClueCalledback;

    public int space = 20;

    public List<Clue> clues = new List<Clue>();


    // return bool, if inventory is full return false so the Item doesn't get destroyed.
    public void Add(Clue clue)
    {

        if (clues.Count >= space)
        {
            Debug.Log("BUG - We screwed up and somehow don't have enough room");
            return;
        }

        clues.Add(clue);

        // Call the delgate to let other method who subscribes to it know.
        if (onClueCalledback != null)
            onClueCalledback.Invoke();

        return;
    }

    public void Remove(Clue clue)
    {
        clues.Remove(clue);
    }
}
