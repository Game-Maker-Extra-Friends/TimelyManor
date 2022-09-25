using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        clues = Resources.LoadAll<Clue>("Clues").ToList();
        onClueCalledback?.Invoke(); // Invkte update when load stuff
    }


    // return bool, if inventory is full return false so the Item doesn't get destroyed.
    public void Add(Clue clue)
    {
        // Call the delgate to let other method who subscribes to it know.
        onClueCalledback?.Invoke();

        return;
    }

    public void Remove(Clue clue)
    {
        clues.Remove(clue);
        clue.seen = false;
    }
}
