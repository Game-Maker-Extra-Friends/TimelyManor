using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.EventSystems;

public class ClueScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public delegate void interact(Clue clue);
	public static event interact ClueInteract;

	// Clue Object Script
	[Header("Clue")]
	public Clue clue;

	public void Start()
    {
		// Set the type to Clue in case people forgot to change it in edito
		// clue.seen = Resources.Load<Save>("Saves/Save").LoadClueState(clue.name);


		if (ES3.KeyExists(clue.name + "Seen", "Saves/ClueSaves.es3"))
		{
			clue.seen = ES3.Load<bool>(clue.name + "Seen", "Saves/ClueSaves.es3");
		}

		if (clue.seen == true && clue.presentationMode == PresentationMode.Simple) DisableInteraction();
    }

	public void Interact()
	{
		if (!clue.seen || clue.presentationMode != PresentationMode.Simple)
		{
			ClueInteract?.Invoke(clue);

			AudioManager.instance.Play("NewClue");
			AudioManager.instance.Play("NewClueFoundSting");
			clue.seen = true;
			ClueInventory.instance.Add(clue);
			

			if (clue.presentationMode == PresentationMode.Simple)
			{
				AudioManager.instance.Play("NewClueFoundSting");
				DisableInteraction();
			}

			//if (clue.presentationMode == PresentationMode.Complex)
			//{
			//	FirstPersonController.instance.playerState = FirstPersonController.PlayerState.Reading;
			//	DisableInteraction();
			//}

			//Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
			ES3.Save(clue.name + "Seen", clue.seen, "Saves/ClueSaves.es3");
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
		else if (GetComponent<Button>() != null)
		{
			GetComponent<Button>().enabled = false;
			GetComponent<Image>().enabled = false;
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		CursorController.instance.ClueCursor();
	}

	public void OnPointerExit(PointerEventData data)
	{
		CursorController.instance.DefaultCursor();
	}


	private void OnApplicationQuit()
	{
		//Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
	}

	private void OnDestroy()
	{
		//Resources.Load<Save>("Saves/Save").SaveClueState(clue.name, clue.seen);
	}
}
