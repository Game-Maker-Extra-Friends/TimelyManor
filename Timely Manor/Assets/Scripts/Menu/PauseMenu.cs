using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    private DontDestroyScript[] dontDestroyObjects;

    //public InputAction exit;
    public StarterAssets.StarterAssetsInputs _input;
    public StarterAssets.FirstPersonController _state;

    public GameObject PauseMenuUI;
    public GameObject OptionMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (_input.exit && _state._playerState != FirstPersonController.PlayerState.Interacting)
        {
            if(GameIsPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _input.exit = false;
                Resume();
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _input.exit = false;
                Pause();
            }
        }
    }


    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");
    }


    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void LoadMenu()
    {
        //Destory all don't destory object so it doesn't screw up the menu
        dontDestroyObjects = FindObjectsOfType<DontDestroyScript>();
        foreach (DontDestroyScript d in dontDestroyObjects)
        {
            Destroy(d.gameObject);
        }

        SceneManager.LoadScene("Menu_Test");
    }
    //public void LoadOption()
    //{
    //    OptionMenuUI.SetActive(true);
    //    PauseMenuUI.SetActive(false);
    //}

    //public void LoadPauseMenu()
    //{
    //    OptionMenuUI.SetActive(false);
    //    PauseMenuUI.SetActive(true);
    //}
}
