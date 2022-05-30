using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceBrickScript : MonoBehaviour
{
	public string value;
	public AudioSource sound;
	public SpriteRenderer sprite;
	private bool isPressed = false;

    public void Interact()
	{
		Toggle();

		if (isPressed)
		{
			FireplaceScript fireplaceScript = GetComponentInParent(typeof(FireplaceScript)) as FireplaceScript;
			fireplaceScript.SetValue(value);
		}
	}

	public void Toggle()
	{
		isPressed = !isPressed;
		sprite.enabled = isPressed;
		sound.Play();
	}

}
