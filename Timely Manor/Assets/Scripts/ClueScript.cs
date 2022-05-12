using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueScript : MonoBehaviour
{
	public Image noteImg;
	public TextMeshProUGUI noteText;
	public Button textButton;
	public Canvas canvas;

	public void toggleCanvas()
	{
		if (canvas.isActiveAndEnabled == false)
		{
			canvas.gameObject.SetActive(true);
		}
		else
		{
			canvas.gameObject.SetActive(false);
		}
	}

	public void toggleNoteText()
	{

		if (noteText.isActiveAndEnabled == false)
			noteText.gameObject.SetActive(true);
		else
			noteText.gameObject.SetActive(false);
	}
}
