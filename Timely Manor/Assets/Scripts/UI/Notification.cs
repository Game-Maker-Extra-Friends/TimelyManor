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


    // Start is called before the first frame update
    public void newMysteryNotification()
    {
        image.gameObject.SetActive(true);
        image.sprite = mysteryAdded;
    }
    public void updatedMysteryNotification()
    {
        image.gameObject.SetActive(true);
        image.sprite = mysteryUpdated;  
    }
    public void solvedMysteryNotification()
    {
        image.gameObject.SetActive(true);
        image.sprite = mysterySolved;
    }
}
