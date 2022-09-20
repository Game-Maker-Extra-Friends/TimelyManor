using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour
{
    public GameObject controls;
    public GameObject hButton;

    Keyboard keyboard = Keyboard.current;
    // Update is called once per frame
    void Update()
    {
        if (keyboard.hKey.wasPressedThisFrame)
        {
            if (controls.active)
            {
                controls.SetActive(false);
                hButton.SetActive(true);
            }
            else
            {
                controls.SetActive(true);
                hButton.SetActive(false);
            }
        }
    }
}
