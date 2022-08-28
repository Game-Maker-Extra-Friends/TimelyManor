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

    public FirstPersonController.PlayerState originalState;

    public Transform currentPageObject;

    // Update is called once per frame
    void Update()
    {
        // Check for exit input + make sure that the player isn't interacting or reading/clue
        if (FirstPersonController.instance.ExitAction.triggered)
        {
            //Check if game is paused or not
            if (FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Paused)
            {
                Resume();
            }
            else if (FirstPersonController.instance.canPause)
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        // Makes the cursor invisible and lock it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FirstPersonController.instance.playerState = FirstPersonController.PlayerState.Moving;
        currentPageObject.gameObject.SetActive(false);
        currentPageObject = gameObject.transform.Find("PauseMenu");
        //PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        Debug.Log("Resume");
        Debug.Log(FirstPersonController.instance.playerState);
    }


    public void Pause()
    {
        // Makes the cursor visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //Redundancy
        FirstPersonController.instance.playerState = FirstPersonController.PlayerState.Paused;
        currentPageObject.gameObject.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log(FirstPersonController.instance.playerState);
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
        //So that when the player play the game again, they don't have to press escape twice
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
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
