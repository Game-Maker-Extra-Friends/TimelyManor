using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockSubmit : MonoBehaviour
{
    public CodeLock codeLock;

    void OnMouseDown()
    {
        Debug.Log("Work");
        codeLock.CheckCode();
    }
}
