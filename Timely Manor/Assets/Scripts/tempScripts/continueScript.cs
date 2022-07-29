using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class continueScript : MonoBehaviour
{
    // Script for passing the intro/outro splash screens
    public string scenename;
    private DontDestroyScript[] dontDestroyObjects;

    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        if (keyboard.anyKey.wasPressedThisFrame || mouse.leftButton.wasPressedThisFrame)
		{
            dontDestroyObjects = FindObjectsOfType<DontDestroyScript>();
            foreach (DontDestroyScript d in dontDestroyObjects)
            {
                Destroy(d.gameObject);
            }
            SceneManager.LoadScene(scenename);
		}

    }
}
