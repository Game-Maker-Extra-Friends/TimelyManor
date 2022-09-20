using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class continueScript : MonoBehaviour
{
    // Script for passing the intro/outro splash screens
    public string scenename;
    private DontDestroyScript[] dontDestroyObjects;

    public Sprite[] introSprites;
    public Image image;

    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        int i = 0;  
        if (keyboard.anyKey.wasPressedThisFrame || mouse.leftButton.wasPressedThisFrame)
		{
            if(i < introSprites.Length)
            {
                image.sprite = introSprites[i];
                i++;
            }
            else
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
}
