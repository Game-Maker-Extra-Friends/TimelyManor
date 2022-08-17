using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class ClueUI : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private GameObject frame;

    private StarterAssetsInputs _input;

    private void Start()
    {
        FirstPersonController.ExitUI += Close;
        ClueScript.ClueInteract += Set;
    }


    public void Set(Clue clue)
    {
        frame.SetActive(true);
        icon.sprite = clue.icon;
        description.text = clue.description;

        
    }

    public void Close()
    {
        frame.SetActive(false);
    }
}
