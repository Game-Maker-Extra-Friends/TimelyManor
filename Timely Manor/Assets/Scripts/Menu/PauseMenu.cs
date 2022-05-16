using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    private DontDestroyScript[] dontDestroyObjects;

    public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        
    }


    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void LoadMenu()
    {
        dontDestroyObjects = FindObjectsOfType<DontDestroyScript>();
        foreach (DontDestroyScript d in dontDestroyObjects)
        {
            Destroy(d.gameObject);
        }

        SceneManager.LoadScene("Menu_Test");
    }
}
