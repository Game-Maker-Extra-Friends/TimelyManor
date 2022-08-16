using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clue", menuName = "Inventory/Clue")]
public class Clue : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string description = "description";

    public Enum.Location location;
    public Enum.Timeline timeline;

    public bool seen;
}
