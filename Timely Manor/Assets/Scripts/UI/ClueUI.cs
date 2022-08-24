using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class ClueUI : MonoBehaviour
{
    [SerializeField]
    private Image simpleIcon;
    [SerializeField]
    private TMP_Text simpleDescription;
    [SerializeField]
    private GameObject simpleFrame;
    [SerializeField]
    private Image longIcon;
    [SerializeField]
    private TMP_Text longDescription;
    [SerializeField]
    private GameObject longFrame;

    private StarterAssetsInputs _input;

    private void Start()
    {
        FirstPersonController.ExitUI += Close;
        ClueScript.ClueInteract += Set;
    }


    public void Set(Clue clue)
    {
        switch (clue.presentationMode)
        {
            case PresentationMode.Simple:

                simpleFrame.SetActive(true);
                simpleIcon.sprite = clue.icon;
                simpleDescription.text = clue.description;

                simpleDescription.GetComponent<LayoutElement>().preferredHeight = clue.description.Length / 2.2f;
                break;
            case PresentationMode.Long:
                longFrame.SetActive(true);
                longIcon.sprite = clue.icon;
                longDescription.text = clue.description;

                longDescription.GetComponent<LayoutElement>().preferredHeight = clue.description.Length/2.2f;
                break;
        }
    }

    public void Close()
    {
        longFrame.SetActive(false);
        simpleFrame.SetActive(false);
    }
}
