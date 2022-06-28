using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Clue Data")]
public class ClueData : ScriptableObject
{
    // to reference easily
    public string id;
    public string displayName;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}
