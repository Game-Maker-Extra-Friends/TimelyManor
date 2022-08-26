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

	// Clue Object Script
	[Header("Clue")]
	public Clue clue;

	public void Start()
    {
		// Set the type to Clue in case people forgot to change it in editor
		interactbleType = InteractbleType.Clue;
		clue.seen = Resources.Load<Save>("Saves/Save").LoadClueState(clue.name);
    }

	public override void Interact()
	{
		if (!clue.seen || clue.presentationMode == PresentationMode.Long)
		{
			Debug.Log("Interacting with clue");
			OnHandlePickupClue();

		
			ClueInteract?.Invoke(clue);
			Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
			clue.seen = true;
		}
		
	}

	// For new clue popups opened via canvas buttons
	public void newClueButton()
	{
		if (!clue.seen)
		{
			clue.seen = true;
			
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
