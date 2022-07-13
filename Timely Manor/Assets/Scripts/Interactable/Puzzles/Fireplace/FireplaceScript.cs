using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceScript : MonoBehaviour
{
    public SpriteRenderer unsolved, fireplaceKey, finished;
    public GameObject key;

    public string code = "12345";
    public string attemptedCode = "";

    public AudioSource Success;

    private void Start()
    {
        if (ES3.KeyExists("CorrectCode", "Saves/FirePlace.es3"))
        {
            attemptedCode = ES3.Load<string>("CorrectCode", "Saves/FirePlace.es3");
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (attemptedCode == code)
        {
            Success.Play();

            foreach (Transform brick in transform)
                brick.gameObject.SetActive(false);

            unsolved.enabled = false;
            fireplaceKey.enabled = true;
            key.SetActive(true);
            ES3.Save("CorrectCode", attemptedCode, "Saves/FirePlace.es3");
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
        if (attemptedCode.Length >= code.Length)
		{
            CheckCode();
		}
    }

    public void RemoveValue(string value)
	{
        string replacementCode = "";

        for (int i = 0; i < attemptedCode.Length; ++i)
		{
            if (attemptedCode[i] != value[0])
			{
                replacementCode += attemptedCode[i];
			}
		}

        attemptedCode = replacementCode;
	}

}
