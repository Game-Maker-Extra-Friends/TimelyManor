using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{

    #region Singleton

    public static Notification instance;

    #endregion

    public Image image;

    public Sprite mysteryAdded;
    public Sprite mysterySolved;
    public Sprite mysteryUpdated;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void newMysteryNotification()
    {
        Debug.Log("New Mystery Notification");
        StartCoroutine(newMysteryCoroutine());
    }
    public void updatedMysteryNotification()
    {
        Debug.Log("Mystery Updated");
        StartCoroutine(mysteryUpdatedCoroutine());
    }
    public void solvedMysteryNotification()
    {
        Debug.Log("Mystery solved Notification");
        
        StartCoroutine(mysterySolvedCoroutine());
    }

    IEnumerator newMysteryCoroutine()
    {
        image.gameObject.SetActive(true);
        image.sprite = mysteryAdded;
        yield return new WaitForSeconds(2f);
        //float alpha = image.transform.GetComponent<Image>().material.color.a;
        //for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.5f)
        //{
        //    Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0f, t));
        //    image.transform.GetComponent<Image>().material.color = newColor;
        //}
        //for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.5f)
        //{
        //    Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1f, t));
        //    image.transform.GetComponent<Image>().material.color = newColor;
        //}
        //for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.5f)
        //{
        //    Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0f, t));
        //    image.transform.GetComponent<Image>().material.color = newColor;
        //}
        //for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.5f)
        //{
        //    Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1f, t));
        //    image.transform.GetComponent<Image>().material.color = newColor;
        //    yield return null;
        //}
        image.gameObject.SetActive(false);
    }
    IEnumerator mysterySolvedCoroutine()
    {
        image.gameObject.SetActive(true);
        image.sprite = mysterySolved;
        yield return new WaitForSeconds(2f);
        image.gameObject.SetActive(false);
    }
    IEnumerator mysteryUpdatedCoroutine()
    {
        image.gameObject.SetActive(true);
        image.sprite = mysteryUpdated;
        yield return new WaitForSeconds(2f);
        image.gameObject.SetActive(false);
    }
}
