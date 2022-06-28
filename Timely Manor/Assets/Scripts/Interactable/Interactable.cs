using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactbleType; // The type of interactable

    public virtual void Interact()
    {
        // Override here.
        Debug.Log("Interacting with: " + transform.name);
    }

}
