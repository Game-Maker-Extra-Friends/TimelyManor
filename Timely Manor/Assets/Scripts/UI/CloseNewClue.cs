using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CloseNewClue : MonoBehaviour
{
    public UIController uIController;

    // Update is called once per frame
    public void CloseOnClick()
    {
        Debug.Log("Close On Click Works + " + uIController.name);
         FirstPersonController.instance.playerState = uIController.ExitUILayer() ? FirstPersonController.PlayerState.Reading : FirstPersonController.PlayerState.Interacting;
    }
}
