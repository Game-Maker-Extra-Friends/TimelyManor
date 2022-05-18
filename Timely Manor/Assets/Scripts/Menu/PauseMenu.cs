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
    public FirstPersonController.PlayerState originalState;

    public Transform currentPageObject;
    // Update is called once per frame
    void Update()
    {
        if (_input.exit && (_state._playerState != FirstPersonController.PlayerState.Interacting && _state._playerState != FirstPersonController.PlayerState.Reading))
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
        _state._playerState = originalState;
        currentPageObject.gameObject.SetActive(false);
        currentPageObject = gameObject.transform.Find("PauseMenu");
        //PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");
    }


    public void Pause()
    {

        //Redundancy
        originalState = _state._playerState;
        _state._playerState = FirstPersonController.PlayerState.Paused;
        currentPageObject.gameObject.SetActive(true);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu_Test");
    }


    public void CurrentPage(string tabName)
    {
        currentPageObject = gameObject.transform.Find(tabName);
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
