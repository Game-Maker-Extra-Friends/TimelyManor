using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject inspectUI;
    public GameObject clueUI;

    private void Start()
    {
        ExitAllUI();
    }

    public void ExitAllUI()
    {
        clueUI.SetActive(false);
        inspectUI.SetActive(false);
    }

    public bool ExitUILayer()
    {

        if (clueUI.activeInHierarchy)
        {
            clueUI.SetActive(false);
            if (inspectUI.activeInHierarchy) return true;
        }
        else if (inspectUI.activeInHierarchy)
        {
            inspectUI.SetActive(false);
        }
        return false;
    }
}
