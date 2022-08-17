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
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    #endregion

    public delegate void OnClueChanged();
    public OnClueChanged onClueCalledback;

    public int space = 20;

    public List<Clue> clues = new List<Clue>();

    private void Start()
    {
        if (ES3.KeyExists("CluesInventory", "Saves/CluesInventory.es3"))
        {
            Debug.Log("Loading Clue");
            clues = ES3.Load<List<Clue>>("CluesInventory", "Saves/CluesInventory.es3");
            Debug.Log(onClueCalledback);
            if (onClueCalledback != null)
            {
               
                onClueCalledback.Invoke(); // Invote update when load stuff
            }
        }
    }


    // return bool, if inventory is full return false so the Item doesn't get destroyed.
    public void Add(Clue clue)
    {
        //prevent duplicates
        if (clues.Contains(clue)) return;

        if (clues.Count >= space)
        {
            Debug.Log("BUG - We screwed up and somehow don't have enough room");
            return;
        }

        clues.Add(clue);

        ES3.Save("CluesInventory", clues, "Saves/CluesInventory.es3");

        // Call the delgate to let other method who subscribes to it know.
        if (onClueCalledback != null)
            onClueCalledback.Invoke();

        return;
    }

    public void Remove(Clue clue)
    {
        clues.Remove(clue);
        ES3.Save("CluesInventory", clues, "Saves/CluesInventory.es3");
    }
}
