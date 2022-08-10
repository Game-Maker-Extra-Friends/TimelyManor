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
	private AudioSource _newClueAudio;
	private ClueUI clueUI;

	[SerializeField]
	private bool seen = false;

	// Clue Object Script
	[Header("Clue")]
	public Clue clue;

	

	[SerializeField]
	//private bool _hasBeenAdded = false;

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
		if(ES3.KeyExists(interactedID, "Saves/ClueSaves.es3"))
			//interacted = ES3.Load<bool>(interactedID, "Saves/ClueSaves.es3");

        if (ES3.KeyExists(interactedID + "Seen", "Saves/ClueSaves.es3"))
        {
			//seen = ES3.Load<bool>(interactedID + "Seen", "Saves/ClueSaves.es3");
        }
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
		if (!seen)
		{
			seen = true;
			
			OnHandlePickupClue();
		}
	}

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
