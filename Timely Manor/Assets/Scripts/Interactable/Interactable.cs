using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactedID; // for saving and loading
    public string interactbleType; // The type of interactable
    public bool interacted = false;


    public virtual void Interact()
    {
        // Override here.
        Debug.Log("Interacting with: " + transform.name);
    }

}
