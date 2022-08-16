using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDontDestroyPrefab : MonoBehaviour
{
    bool prefabExist = false;
    GameObject[] objectWithScript;
    public GameObject dontDestroyPrefab;

    void Start()
    {
        objectWithScript = GameObject.FindGameObjectsWithTag("DontDestroy");
        foreach (GameObject go in objectWithScript)
        {
            if (go.name == "DontDestroyGameObjectPrefabGroup(Clone)")
            {
                prefabExist = true;
            }
        }
        if(prefabExist == false)
        {
            // Try to set it to 0, 0, 0 for consistency 
            Instantiate(dontDestroyPrefab, gameObject.transform.position, gameObject.transform.rotation);
            prefabExist = false;
        }
    }

}
