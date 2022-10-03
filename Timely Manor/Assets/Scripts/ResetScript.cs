using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.altKey.isPressed && Keyboard.current.rKey.isPressed)
        {
            Resources.Load<Save>("Saves").Reset();
            SceneManager.LoadScene("Present");
        }
    }
}
