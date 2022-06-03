using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueObject : MonoBehaviour
{
    public ClueData referenceItem;

    [SerializeField]
    private bool _hasBeenAdded = false;

    public void OnHandlePickupClue()
    {
        // If the clue hasn't been added, add it.
        if(_hasBeenAdded == false)
        {
            // Debug.Log(referenceItem);
            ClueSystem.currentClueSystem.Add(referenceItem);
            _hasBeenAdded = true;
        }
        
    }
}
