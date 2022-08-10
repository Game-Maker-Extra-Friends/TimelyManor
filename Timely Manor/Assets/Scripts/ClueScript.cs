using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ClueScript : Interactable
{
	[Header("Clue")]
	public TextMeshProUGUI noteText;
	public Canvas canvas = null;
	private AudioSource _audioSource;

	[Header("New Clue Popup")]
	public Canvas newClueCanvas;
	[SerializeField]
	private bool seen = false;
	private AudioSource _newClueAudio;

	public void Start()
    {
		Component[] audioSources;
		audioSources = GetComponents(typeof(AudioSource));
		
		if (audioSources.Length > 0)
			_audioSource = (AudioSource)audioSources[0];
		//_newClueAudio = (AudioSource)audioSources[1];


		// Set the type to Clue in case people forgot to change it in editor
		interactbleType = InteractbleType.Clue;
		if(ES3.KeyExists(interactedID, "Saves/ClueSaves.es3"))
			interacted = ES3.Load<bool>(interactedID, "Saves/ClueSaves.es3");

        if (ES3.KeyExists(interactedID + "Seen", "Saves/ClueSaves.es3"))
        {
			seen = ES3.Load<bool>(interactedID + "Seen", "Saves/ClueSaves.es3");
        }
    }

	public override void Interact()
	{
		StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.Reading;
		OnHandlePickupClue();
		if (!seen)
		{
			StarterAssets.FirstPersonController.instance.openNewClue = this.transform.gameObject;
			newClueCanvas.gameObject.SetActive(true);
			seen = true;
			if(_audioSource != null)
				_audioSource.Play();
		}
		else 
		{
			if (canvas != null)
			{
				toggleCanvas();
				_audioSource.Play();
			}
			else
			{
				StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
			}
		}
		// Debug.Log("OnHandleCalled");
		
	}


    public void toggleCanvas()
	{

		if (newClueCanvas.isActiveAndEnabled == false)
		{
			if (canvas != null)
			{
				if (canvas.isActiveAndEnabled == false)
				{
					StarterAssets.FirstPersonController.instance.openNote = this.transform.gameObject;
					canvas.gameObject.SetActive(true);
					_audioSource.Play();
				}
				else
				{
					StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
					canvas.gameObject.SetActive(false);
				}
			}
			else
			{
				StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
			}
		}
		


		if (!seen && newClueCanvas.isActiveAndEnabled == false)
		{
			newClueCanvas.gameObject.SetActive(true);
			seen = true;
			ES3.Save(interactedID + "Seen", seen, "Saves/ClueSaves.es3");
		}
		else if (seen && newClueCanvas.isActiveAndEnabled == true)
		{
			newClueCanvas.gameObject.SetActive(false);
			if (canvas != null)
			{
				canvas.gameObject.SetActive(true);
				StarterAssets.FirstPersonController.instance.openNote = this.transform.gameObject;
			}
			else if (StarterAssets.FirstPersonController.instance.openNote == null)
			{ 
				// new clues opened via canvas buttons break here when closed
				StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
			}
		}

		
	}

	// For new clue popups opened via canvas buttons
	public void newClueButton()
	{
		if (!seen)
		{
			StarterAssets.FirstPersonController.instance.openNewClue = this.transform.gameObject;
			newClueCanvas.gameObject.SetActive(true);
			seen = true;
			
			OnHandlePickupClue();
		}
	}





	// Clue Object Script
	[Header("Clue Object")]
	public Clue clue;


	[SerializeField]
	//private bool _hasBeenAdded = false;

	public void OnHandlePickupClue()
	{
		Debug.Log("Picking up: " + clue.name);
		if(interacted == false)
		{
			AudioManager.instance.Play("NewClue");
			ClueInventory.instance.Add(clue);
			//_hasBeenAdded = true;
			interacted = true;
			ES3.Save(interactedID, interacted, "Saves/ClueSaves.es3");
			ES3.Save(interactedID + "Seen", seen, "Saves/ClueSaves.es3");
		}
	}

}
