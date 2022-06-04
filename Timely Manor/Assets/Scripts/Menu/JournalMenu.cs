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
    public Transform nextPageObject;

    // Update is called once per frame
    void Update()
    {
        // Open journal: Check for open journal input, if journal is not open and that player is in moving state
        if (_input.openJournal && !journalOpened && _state._playerState == FirstPersonController.PlayerState.Moving) 
        {
            _input.openJournal = false;
            OpenJournal();
        }

        // Close journal: check for either exit or open journal input and if journal is open
        if ((_input.exit || _input.openJournal) && journalOpened)
		{
            _input.exit = false;
            _input.openJournal = false;
            CloseJournal();
		}

        //Put here so that the if statement doesn't get spam from the input being active
        _input.openJournal = false;
    }


    public void CloseJournal()
    {
        //Return the state to the original
        _state._playerState = originalState;

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
        originalState = _state._playerState;
        // Set the player state to Journal 
        _state._playerState = FirstPersonController.PlayerState.Journal;
        // Makes the cursor visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Open the current page, e.g. if the player close on the inventory page, when the player open the journal again it will be on journal page
        currentPageObject.gameObject.SetActive(true);

        //Pause time (Might be removed later since it will probably screw up the camrea)
        Time.timeScale = 0f;

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
