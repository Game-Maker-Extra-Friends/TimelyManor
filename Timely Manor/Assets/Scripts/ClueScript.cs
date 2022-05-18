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
	private AudioSource _audioSource;

    public void Start()
    {
		_audioSource = GetComponent<AudioSource>();
    }

    public void toggleCanvas()
	{
		if (canvas.isActiveAndEnabled == false)
		{
			canvas.gameObject.SetActive(true);
			_audioSource.Play();
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
