using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using StarterAssets;

public class ClueScript : MonoBehaviour
{
	public delegate void interact(Clue clue);
	public static event interact ClueInteract;

	// Clue Object Script
	[Header("Clue")]
	public Clue clue;

	public void Start()
    {
		// Set the type to Clue in case people forgot to change it in edito
		clue.seen = Resources.Load<Save>("Saves/Save").LoadClueState(clue.name);
    }

	public void Interact()
	{
		if (!clue.seen || clue.presentationMode == PresentationMode.Long)
		{
			Debug.Log("Interacting with clue");

			AudioManager.instance.Play("NewClue");
			ClueInventory.instance.Add(clue);

			ClueInteract?.Invoke(clue);
			clue.seen = true;
			Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
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
