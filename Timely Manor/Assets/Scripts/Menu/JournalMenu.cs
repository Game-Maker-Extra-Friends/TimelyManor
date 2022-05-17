using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using StarterAssets;

public class JournalMenu : MonoBehaviour
{
    public static bool journalOpened = false;
    private DontDestroyScript[] dontDestroyObjects;

    //public InputAction exit;
    public StarterAssets.StarterAssetsInputs _input;
    public StarterAssets.FirstPersonController _state;
    public FirstPersonController.PlayerState originalState;

    enum currentPage
    {
        Journal,
        Notes,
        Inventory,
        Investigation
    }

    public Transform currentPageObject;
    // Update is called once per frame
    void Update()
    {
        if (_input.openJournal && _state._playerState != FirstPersonController.PlayerState.Interacting)
        {
            _input.openJournal = false;
            Debug.Log("Journal open");
            if (journalOpened)
            {
                _state._playerState = originalState;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;  
                CloseJournal();
            }
            else
            {
                originalState = _state._playerState;
                _state._playerState = FirstPersonController.PlayerState.Journal;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                OpenJournal();
            }
        }
    }


    public void CloseJournal()
    {
        currentPageObject.gameObject.SetActive(false);
        Time.timeScale = 1f;
        journalOpened = false;
        Debug.Log("Journal opened");
    }


    public void OpenJournal()
    {
        currentPageObject.gameObject.SetActive(true);
        Time.timeScale = 0f;
        journalOpened = true;
    }

    public void CurrentPage(string tabName)
    {
        currentPageObject = gameObject.transform.Find(tabName);
    }

    //public void LoadMenu()
    //{
    //    //Destory all don't destory object so it doesn't screw up the menu
    //    dontDestroyObjects = FindObjectsOfType<DontDestroyScript>();
    //    foreach (DontDestroyScript d in dontDestroyObjects)
    //    {
    //        Destroy(d.gameObject);
    //    }

    //    SceneManager.LoadScene("Menu_Test");
    //}
}
