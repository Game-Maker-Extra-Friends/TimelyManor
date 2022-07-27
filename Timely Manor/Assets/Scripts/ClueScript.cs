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
		StarterAssets.FirstPersonController.Instance._playerState = StarterAssets.FirstPersonController.PlayerState.Reading;

		if (!seen)
		{
			StarterAssets.FirstPersonController.Instance._openNewClue = this.transform.gameObject;
			newClueCanvas.gameObject.SetActive(true);
			seen = true;
		}
		else 
		{
			if (canvas != null)
			{
				toggleCanvas();
			}
			else
			{
				StarterAssets.FirstPersonController.Instance._playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
			}
		}

		OnHandlePickupClue();
	}


    public void toggleCanvas()
	{

		if (newClueCanvas.isActiveAndEnabled == false)
		{
			if (canvas != null)
			{
				if (canvas.isActiveAndEnabled == false)
				{
					StarterAssets.FirstPersonController.Instance._openNote = this.transform.gameObject;
					canvas.gameObject.SetActive(true);
					_audioSource.Play();
				}
				else
				{
					StarterAssets.FirstPersonController.Instance._playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
					canvas.gameObject.SetActive(false);
				}
			}
			else
			{
				StarterAssets.FirstPersonController.Instance._playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
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
				StarterAssets.FirstPersonController.Instance._openNote = this.transform.gameObject;
			}
			else
			{ 
				// new clues opened via canvas buttons break here when closed
				//StarterAssets.FirstPersonController.Instance._playerState = StarterAssets.FirstPersonController.PlayerState.Interacting;
			}
		}

		
	}

	// For new clue popups opened via canvas buttons
	public void newClueButton()
	{
		if (!seen)
		{
			StarterAssets.FirstPersonController.Instance._openNewClue = this.transform.gameObject;
			newClueCanvas.gameObject.SetActive(true);
			seen = true;
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
			ClueInventory.instance.Add(clue);
			//_hasBeenAdded = true;
			interacted = true;
			ES3.Save(interactedID, interacted, "Saves/ClueSaves.es3");
		}
	}

}
