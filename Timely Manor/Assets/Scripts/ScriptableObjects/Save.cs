using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class InventoryObjectState
{
    public InventoryObjectState(string name, bool state)
    {
        objectName = name;
        pickedUp = state;
    }

    public string objectName;
    public bool pickedUp;
}

[CreateAssetMenu]
public class Save : ScriptableObject
{
    [Header("Progress")]
    public List<InventoryObjectState> itemInventoryObjectStates;
    public List<InventoryObjectState> clueInventoryObjectStates;

    public bool fireplaceSolved;

    [Header("Audio Settings")]
    public float masterVolume;
    public float sfxVolume;
    public float musicVolume;
    [Header("Video Settings")]
    public int resolutionIndex;
    public int graphicQuality;
    public bool fullscreen;
    [Header("Control Settings")]
    public float mouseSensitivity;

    //Set all progress to 0
    public void Reset()
    {
        foreach (Clue c in Resources.LoadAll<Clue>("Clues"))
        {
            SaveClueState(c.name, false);
        }
        foreach (Item i in Resources.LoadAll<Item>("Items"))
        {
            SaveItemState(i.name, false);
        }
        fireplaceSolved = false;
    }

    // Gets state of item, returns null if not found
    public bool LoadItemState(string itemName)
    {
        return LoadInventoryObjectState(itemInventoryObjectStates, itemName);
    }

    public void SaveItemState(string itemName, bool pickedUp)
    {
        SaveInventoryObjectState(itemInventoryObjectStates, itemName, pickedUp);
    }

    public bool LoadClueState(string clueName)
    {
        return LoadInventoryObjectState(clueInventoryObjectStates, clueName);
    }

    public void SaveClueState(string clueName, bool pickedUp)
    {
        SaveInventoryObjectState(clueInventoryObjectStates, clueName, pickedUp);
    }

    private bool LoadInventoryObjectState(List<InventoryObjectState> states, string name)
    {
        InventoryObjectState s = states.Where(x => x.objectName == name).FirstOrDefault();
        return s == null ? false : s.pickedUp;
    }

    private void SaveInventoryObjectState(List<InventoryObjectState> states, string name, bool pickedUp)
    {
        // Try to get existing save state
        InventoryObjectState s = states.Where(x => x.objectName == name).FirstOrDefault();

        // Create new if not found
        if (s == null)
        {
            states.Add(new InventoryObjectState(name, pickedUp));
        }
        // Edit existing
        else
        {
            s.pickedUp = pickedUp;
        }
    }
}
