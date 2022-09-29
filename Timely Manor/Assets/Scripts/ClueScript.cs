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

		if (clue.seen == true && clue.presentationMode == PresentationMode.Simple) DisableInteraction();
    }

	public void Interact()
	{
		if (!clue.seen || clue.presentationMode != PresentationMode.Simple)
		{
			Debug.Log("Interacting with clue");
			ClueInteract?.Invoke(clue);

			AudioManager.instance.Play("NewClue");
			AudioManager.instance.Play("NewClueFoundSting");
			ClueInventory.instance.Add(clue);
			clue.seen = true;

			if (clue.presentationMode == PresentationMode.Simple)
			{
				AudioManager.instance.Play("NewClueFoundSting");
				DisableInteraction();
			}
			Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
		}
	}

	private void DisableInteraction()
	{
		if (GetComponent<BoxCollider>() != null)
		{
			BoxCollider[] col = GetComponents<BoxCollider>();
			foreach(BoxCollider c in col)
            {
				c.enabled = false;
            }
		}
		else
		{
			GetComponent<Button>().enabled = false;
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
