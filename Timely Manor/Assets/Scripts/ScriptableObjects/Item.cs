using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Texture icon = null;
    public string description = "description";


    //public bool isDefaultItem = false;
    public bool pickedUp;
    
}
