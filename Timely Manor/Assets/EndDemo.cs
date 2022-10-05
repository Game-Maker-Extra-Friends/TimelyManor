using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndDemo : MonoBehaviour
{
    public float transitionTime = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "OutroCart")
        {
            StartCoroutine(EndOfAllThings());
        }
    }

    IEnumerator EndOfAllThings()
    {        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("OutroScene");
    }

}
