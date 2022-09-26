using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInteract : MonoBehaviour
{
    public ClueScript clueObject;

    private void Update()
    {
        if (clueObject.clue.seen)
        {
            Destroy(gameObject);
        }
    }
}
