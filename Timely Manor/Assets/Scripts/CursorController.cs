using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    #region Singleton

    public static CursorController instance;

	private InputAction clickAction;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);

		clickAction = FindObjectOfType<PlayerInput>().actions["ClickInput"];
    }

    #endregion

    public Texture2D cursorTexture, inspectCursorTexture;

    public void DefaultCursor()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

	public void ClueCursor()
    {
        Cursor.SetCursor(inspectCursorTexture, Vector2.zero, CursorMode.Auto);
    }

	public void ItemCursor(Texture image)
    {
		Cursor.SetCursor(image as Texture2D, Vector2.zero, CursorMode.Auto);
    }

	public void OnPointerEnter(PointerEventData data)
	{
		if (data.selectedObject.CompareTag("Clickable"))
		{
			ClueCursor();
		}
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (data.selectedObject.CompareTag("Clickable"))
		{
			DefaultCursor();
		}
	}

	private void Update()
	{
		if (FirstPersonController.instance.Interacting)
		{
			PointAndClick();
		}
	}

	public void PointAndClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			if (FirstPersonController.instance.GetEquippedItem() != null)
            {
				if (hit.transform.gameObject.GetComponent<ItemInteract>() != null)
                {

                }

				ItemCursor(FirstPersonController.instance.GetEquippedItem().icon);
            }
			else
			{ 
				// Change mouse cursor as appropriate
				if (hit.transform.gameObject.CompareTag("Clickable"))
				{
					ClueCursor();
				}
				else
				{
					DefaultCursor();
				}

				if (clickAction.triggered)
				{
					if (hit.transform.gameObject.CompareTag("Clickable") || hit.transform.gameObject.CompareTag("PickupObject"))
					{
						hit.transform.gameObject.SendMessage("Interact");
					}

					CodeLock codeLock = hit.transform.gameObject.GetComponentInParent<CodeLock>();
					if (hit.transform.gameObject.CompareTag("SafePuzzleNumber")) //for Codelock puzzle, if script CodeLock return not null 
					{
						string value = hit.transform.name;
						codeLock.SetValue(value);
					}
					else if (hit.transform.gameObject.CompareTag("SafePuzzleSubmit"))
					{
						codeLock.CheckCode();
					}

					if (hit.transform.gameObject.CompareTag("LetterUp"))
					{
						hit.transform.gameObject.GetComponent<UpButton>().ChangeLetterUp();
					}
					else if (hit.transform.gameObject.CompareTag("LetterDown"))
					{
						hit.transform.gameObject.GetComponent<DownButton>().ChangeLetterDown();
					}
					else if (hit.transform.gameObject.CompareTag("LetterSubmit"))
					{
						hit.transform.gameObject.GetComponent<SubmitLetterPuzzle>().Submit();
					}
				}
			}
		}
	}
}
