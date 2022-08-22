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
        CheckCode();
    }

    private void CheckCode()
    {
        Save save = Resources.Load<Save>("Saves/Save");

        if (attemptedCode == code || save.LoadFireplaceState(name))
        {
            Debug.Log("unlocked");
            Success.Play();

            foreach (Transform brick in transform)
                brick.gameObject.SetActive(false);

            unsolved.enabled = false;
            fireplaceKey.enabled = true;
            if (key != null) key.SetActive(true);
            save.SaveFireplaceState(name, true);
        }
        else
        {
            attemptedCode = null;
            foreach (Transform brick in transform)
			{
                brick.SendMessage("ResetState");
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
