using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class ClueCounting : MonoBehaviour
{
    public ClueScript[] clues;
    public int count = 0;

    public Sprite cluesLeft;
    public Sprite noCluesLeft;

    public GameObject parent;

    // For enableing and disabling
    public Image image;
    public TextMeshProUGUI text;

    public static ClueCounting instance;
    private Collider currentCollider;


    void Start()
    {
        instance = this;
    }

    public void updateCurrentClue(Collider col)
    {
        // Get the parent so we can find all the clues of the child
        // All this is assuming we are using the same way we do Interact point in heirachy (which should be always)
        parent = col.gameObject.transform.parent.gameObject;
        clues = parent.GetComponentsInChildren<ClueScript>();
        count = clues.Length;

        foreach (ClueScript cs in clues)
        {
            if (cs.clue.seen == true)
            {
                count--;
            }
        }
        currentCollider = col;
    }

    // When walking over new Interact point
    public void updateButtonPrompt(Collider col)
    {
        updateCurrentClue(col);
        if (count == 0 && FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Moving)
        {
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            image.sprite = noCluesLeft;

            // Set image transparency
            var tempColour = image.color;
            tempColour.a = 0.3f;
            image.color = tempColour;
        }
        else if (count > 0 && FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Moving)
        {
            updateCurrentClue(currentCollider);
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            image.sprite = cluesLeft;

            // Set image transparecny
            var tempColour = image.color;
            tempColour.a = 1f;
            image.color = tempColour;
        }
    }

    public void disable()
    {
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    void Update()
    {
        if(count == 0 && FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Interacting)
        {
            // Set image transparecny
            var tempColour = image.color;
            tempColour.a = 0.3f;
            image.color = tempColour;

            image.gameObject.SetActive(true);
            image.sprite = noCluesLeft;
            
        }
        else if(count > 0 && FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Interacting)
        {
            // Set image transparecny
            var tempColour = image.color;
            tempColour.a = 1f;
            image.color = tempColour;

            updateCurrentClue(currentCollider);
            image.gameObject.SetActive(true);
            image.sprite = cluesLeft;

        }
    }
}
