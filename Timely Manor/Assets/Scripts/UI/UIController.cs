using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Transform canvas;

    public GameObject inspectUI;
    public GameObject clueUI;
    public GameObject uiInstance;

    private void Start()
    {
        ExitAllUI();
        ClueScript.ClueInteract += ClueInteract;
    }

    public void ClueInteract(Clue clue)
    {
        if (clue.presentationMode == PresentationMode.Complex)
        {
            CreateUIElement(clue.display);
        }
    }

    public void ExitAllUI()
    {
        clueUI.SetActive(false);
        inspectUI.SetActive(false);
        Destroy(uiInstance);
        uiInstance = null;
    }

    public void CreateUIElement(GameObject element)
    {
        uiInstance = Instantiate(element, canvas);
        uiInstance.transform.SetAsFirstSibling();
    }

    public bool ExitUILayer()
    {
        if (clueUI.activeInHierarchy)
        {
            clueUI.SetActive(false);
            if (inspectUI.activeInHierarchy || uiInstance != null) return true;
        }
        else
        {
            inspectUI.SetActive(false);
            Destroy(uiInstance);
            uiInstance = null;
        }
        return false;
    }
}
