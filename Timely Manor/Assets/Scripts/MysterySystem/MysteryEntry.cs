using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MysteryEntry
{
    public string text;
    public List<Clue> triggers;
    public bool revealed;
}
