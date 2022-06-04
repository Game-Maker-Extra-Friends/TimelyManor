using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class keyScript : MonoBehaviour
{

	public GameObject dontdestroy;
    public void Interact()
	{
		Destroy(dontdestroy);
		SceneManager.LoadScene("outroScene");
	}
}
