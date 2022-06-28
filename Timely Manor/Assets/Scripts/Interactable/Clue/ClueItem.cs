using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClueItem : MonoBehaviour
{
    public ClueData data { get; private set; }
    public int stackSize { get; private set; }

    //Pass and set the data
    public ClueItem(ClueData source)
    {
        data = source;
        AddToStack();
    }

    // For objects that can be stacked (Maybe not used in our game)
    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
