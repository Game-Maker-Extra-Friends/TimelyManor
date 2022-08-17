using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using StarterAssets;

public class ClueScript : Interactable
{
	public delegate void interact(Clue clue);
	public static event interact ClueInteract;

	private AudioSource _audioSource;
	private ClueUI clueUI;

	// Clue Object Script
	[Header("Clue")]
	public Clue clue;

	[Header("New Clue Popup")]
	public Canvas newClueCanvas;
	private AudioSource _newClueAudio;

	public void Start()
    {
		Component[] audioSources;
		audioSources = GetComponents(typeof(AudioSource));

		clueUI = FindObjectOfType<ClueUI>();

		if (audioSources.Length > 0)
			_audioSource = (AudioSource)audioSources[0];
		//_newClueAudio = (AudioSource)audioSources[1];


		// Set the type to Clue in case people forgot to change it in editor
		interactbleType = InteractbleType.Clue;
		clue.seen = Resources.Load<Save>("Saves/Save").LoadClueState(name);
    }

	public override void Interact()
	{
		
		OnHandlePickupClue();

		
		if (!seen)
		{
			ClueInteract?.Invoke(clue);
			seen = true;
		}
		_audioSource?.Play();
		
	}

	// For new clue popups opened via canvas buttons
	public void newClueButton()
	{
		if (!clue.seen)
		{
			seen = true;
			
			OnHandlePickupClue();
		}
	}

	public void OnHandlePickupClue()
	{
		//Debug.Log("Picking up: " + clue.name);
		if(interacted == false)
		{
			AudioManager.instance.Play("NewClue");
			ClueInventory.instance.Add(clue);
			//_hasBeenAdded = true;
			interacted = true;
			clue.seen = true;
		}
	}


	private void OnApplicationQuit()
	{
		Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
	}

	private void OnDestroy()
	{
		Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
	}
}
