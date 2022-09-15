using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectUI : MonoBehaviour
{
    public GameObject frame;
    public Image icon;
    public TMP_Text description;

    public void Start()
    {
        ClueScript.ClueInteract += Open;
    }

    public void Open(Clue clue)
    {
        if (clue.presentationMode == PresentationMode.Long)
        {
            frame.SetActive(true);
            icon.sprite = clue.icon;
            description.text = clue.content;
        }
    }

    public void Close()
    {
        frame.SetActive(false);
    }
}
