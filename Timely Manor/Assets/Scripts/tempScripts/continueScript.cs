using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class continueScript : MonoBehaviour
{
    // Script for passing the intro/outro splash screens
    public string scenename;
    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        if (keyboard.anyKey.wasPressedThisFrame || mouse.leftButton.wasPressedThisFrame)
		{
            SceneManager.LoadScene(scenename);
		}

    }
}
