using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using StarterAssets;

public class JournalMenu : MonoBehaviour
{
    public static bool journalOpened = false;
    private DontDestroyScript[] dontDestroyObjects;

    // For accessing exit input
    public StarterAssets.StarterAssetsInputs input;
    public StarterAssets.FirstPersonController state;
    public FirstPersonController.PlayerState originalState;

    enum currentPage
    {
        Journal,
        Notes,
        Inventory,
        Investigation
    }

    public Transform currentPageObject;
    public Transform nextPageObject;

    // Update is called once per frame
    void Update()
    {
        // Open journal: Check for open journal input, if journal is not open and that player is in moving state
        if (input.openJournal && !journalOpened && state.playerState == FirstPersonController.PlayerState.Moving) 
        {
            input.openJournal = false;
            OpenJournal();
        }

        // Close journal: check for either exit or open journal input and if journal is open
        if ((input.exit || input.openJournal) && journalOpened)
		{
            input.exit = false;
            input.openJournal = false;
            CloseJournal();
		}

        //Put here so that the if statement doesn't get spam from the input being active
        input.openJournal = false;
    }


    public void CloseJournal()
    {
        //Return the state to the original
        state.playerState = originalState;
        // AudioManager.instance.Stop("PauseTheme");
        if (FirstPersonController.instance._timeState == FirstPersonController.TimeState.Past)
        {
            // AudioManager.instance.Play("MusicPast");
            AudioManager.instance.FadeOut("PauseTheme", "MusicPast");
        }
        else
        {
            // AudioManager.instance.Play("MusicPresent");
            AudioManager.instance.FadeOut("PauseTheme", "MusicPresent");
        }
        // Makes the cursor invisible and lock it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Need an event here just for close journal so inventory can delete.
        JournalCloseChangeEvent();


        // Close the current page
        currentPageObject.gameObject.SetActive(false);

        // Unpause the game
        Time.timeScale = 1f;
        journalOpened = false;
        Debug.Log("Journal opened");
        
    }


    public void OpenJournal()
    {
        // Save the current sate so that they can resume
        originalState = state.playerState;
        // Set the player state to Journal 
        state.playerState = FirstPersonController.PlayerState.Journal;
        // Makes the cursor visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Debug.Log("The Audio Manager is:" + AudioManager.instance.name);
        // AudioManager.instance.Play("PauseTheme");
        if(FirstPersonController.instance._timeState == FirstPersonController.TimeState.Past)
        {
            AudioManager.instance.FadeOut("MusicPast", "PauseTheme");
            // AudioManager.instance.Stop("MusicPast");
        }
        else
        {
            // AudioManager.instance.Stop("MusicPresent");
            //Debug.Log("Fading out Present and in Pause");
            AudioManager.instance.FadeOut("MusicPresent", "PauseTheme");
        }
        // Open the current page, e.g. if the player close on the inventory page, when the player open the journal again it will be on journal page
        currentPageObject.gameObject.SetActive(true);

        //Pause time (Might be removed later since it will probably screw up the camrea)
        // Time.timeScale = 0f;

        journalOpened = true;
        if(currentPageObject.name == "InventoryTab")
        {
            // Reset Clues and Inventory if there is any
            JournalCloseChangeEvent();
            // Load Inventory if the last page closed is inventory
            JournalOpenChangeEventInventory();
        }
        else if(currentPageObject.name == "NotesTab")
        {
            // Reset Clues and Inventory if there is any
            JournalCloseChangeEvent();
            // Load Clue if the last page closed is clues
            JournalOpenChangeEventClue();
        }
    }

    //So the player can close the UI when the page changes + the bonus of opening the same page the player left off from.
    public void SetCurrentPage(string tabName)
    {
        currentPageObject = gameObject.transform.Find(tabName);
    }

    public void ChangePage(string nextPageName)
    {
        currentPageObject.gameObject.SetActive(false);
        SetCurrentPage(nextPageName);
        currentPageObject.gameObject.SetActive(true);
        if(nextPageName == "InventoryTab")
        {
            // Reset Clues if there is any
            JournalCloseChangeEvent();
            // Load inventory if the page is changing to inventory
            JournalOpenChangeEventInventory();
        }
        else if (nextPageName == "NotesTab")
        {
            // Reset Inventory if there is any
            JournalCloseChangeEvent();
            // For Updating Clues Tab
            JournalOpenChangeEventClue();
        }
        else
        {
            // Reset inventory if other page is open
            JournalCloseChangeEvent();
        }
    }

    // For Inventory
    public event Action onJournalOpenEvent;
    public event Action onJournalCloseEvent;

    public event Action onJournalOpenEventClue;


    // Add and remove calls this to let others who listen in to know that inventory has changed.
    public void JournalOpenChangeEventInventory()
    {
        if (onJournalOpenEvent != null)
        {
            onJournalOpenEvent();
        }
    }

    // So the inventory can remove the child object.
    public void JournalCloseChangeEvent()
    {
        if (onJournalCloseEvent != null)
        {
            onJournalCloseEvent();
        }
    }


    public void JournalOpenChangeEventClue()
    {
        if (onJournalOpenEventClue != null)
        {
            onJournalOpenEventClue();
        }
    }


}
