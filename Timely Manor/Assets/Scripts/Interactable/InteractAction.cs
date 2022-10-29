using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using StarterAssets;

public class InteractAction : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask UseLayers;

    public GameObject followCamera;


    public void OnInteract()
    {
        if (FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Interacting)
        {
        }
        else
        {
            if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
            {
                if (hit.collider.tag == "InteractLook")
                {
                    FirstPersonController.instance.EnterInteract(hit.collider);
                }
                else
                {
                    ClueCounting.instance.disable();
                }
            }
        }
        
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers) && hit.collider.tag == "InteractLook")
        {
            ClueCounting.instance.updateCurrentClue(hit.collider);
            ClueCounting.instance.updateButtonPrompt(hit.collider);
        }
        else
        {
            ClueCounting.instance.disable();
        }
    }

}
