using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class keyScript : Interactable
{

	public GameObject dontdestroy;
    public override void Interact()
	{
		Destroy(dontdestroy);
		SceneManager.LoadScene("outroScene");
	}
}
