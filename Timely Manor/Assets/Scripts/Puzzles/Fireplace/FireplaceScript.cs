using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceScript : MonoBehaviour
{
    public SpriteRenderer unsolved, finished, key;

    public string code = "12345";
    public string attemptedCode = "";

    public AudioSource Success;

    private void CheckCode()
    {
        if (attemptedCode == code)
        {
            Success.Play();

            foreach (Transform brick in transform)
                brick.gameObject.SetActive(false);

            unsolved.enabled = false;
            key.enabled = true;
        }
        else
        {
            attemptedCode = null;
            foreach (Transform brick in transform)
			{
                brick.SendMessage("Toggle");
			}
        }
    }


    public void SetValue(string value)
    {
        attemptedCode += value;
        if (attemptedCode.Length >= 5)
		{
            CheckCode();
		}
    }
}
