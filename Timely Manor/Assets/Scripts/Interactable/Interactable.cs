using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactedID; // for saving and loading

    // The type of interactable
    public enum InteractbleType
    {
        Item,
        Clue
    };

    public bool interacted = false;

    public InteractbleType interactbleType;

    public virtual void Interact()
    {
        // Override here.
        Debug.Log("Interacting with: " + transform.name);
    }

}
