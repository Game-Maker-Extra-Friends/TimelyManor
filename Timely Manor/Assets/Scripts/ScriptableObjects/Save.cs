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

[System.Serializable]
public class FlowerLockObjectState
{
    public FlowerLockObjectState(string name, int num)
    {
        objectName = name;
        currentImgNum = num;
    }

    public string objectName;
    // For Flower Lock puzzle
    public int currentImgNum;
}

[CreateAssetMenu]
public class Save : ScriptableObject
{
    [Header("Progress")]
    public List<InventoryObjectState> itemInventoryObjectStates;
    public List<InventoryObjectState> clueInventoryObjectStates;
    public List<InventoryObjectState> fireplaceStates;
    public List<FlowerLockObjectState> flowerLockStates;

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
            c.seen = false;
        }
        foreach (Item i in Resources.LoadAll<Item>("Items"))
        {
            SaveItemState(i.name, false);
            i.pickedUp = false;
        }
        foreach (InventoryObjectState i in fireplaceStates)
        {
            SaveFireplaceState(i.objectName, false);
        }
        foreach (FlowerLockObjectState i in flowerLockStates)
        {
            SaveFlowerPuzzleState(i.objectName, 0);
        }
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

    public bool LoadFireplaceState(string fireplaceName)
    {
        return LoadInventoryObjectState(fireplaceStates, fireplaceName);
    }

    public void SaveFireplaceState(string fireplaceName, bool completed)
    {
        SaveInventoryObjectState(fireplaceStates, fireplaceName, completed);
    }

    public void SaveFlowerPuzzleState(string flowerPuzzleName, int currentImgNum)
    {
        SaveFlowerObjectState(flowerLockStates ,flowerPuzzleName, currentImgNum);
    }
    public int LoadFlowerPuzzleState(string flowerPuzzleName)
    {
        return LoadFlowerLockObjectState(flowerLockStates, flowerPuzzleName);
    }


    private bool LoadInventoryObjectState(List<InventoryObjectState> states, string name)
    {
        InventoryObjectState s = states.Where(x => x.objectName == name).FirstOrDefault();
        return s == null ? false : s.pickedUp;
    }

    private int LoadFlowerLockObjectState(List<FlowerLockObjectState> states, string name)
    {
        FlowerLockObjectState s = states.Where(x => x.objectName == name).FirstOrDefault();
        return s == null ? 0 : s.currentImgNum;
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

    private void SaveFlowerObjectState(List<FlowerLockObjectState> states, string name, int currentImgNum)
    {
        // Try to get existing save state
        FlowerLockObjectState s = states.Where(x => x.objectName == name).FirstOrDefault();

        // Create new if not found
        if (s == null)
        {
            states.Add(new FlowerLockObjectState(name, currentImgNum));
        }
        // Edit existing
        else
        {
            s.currentImgNum = currentImgNum;
        }
    }
}
