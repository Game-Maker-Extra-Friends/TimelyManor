using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class ClueCounting : MonoBehaviour
{
    public ClueScript[] clues;
    public int count = 0;

    public Sprite cluesLeft;
    public Sprite noCluesLeft;

    public GameObject parent;

    public Image image;
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

    void Update()
    {
        if(count == 0 && FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Interacting)
        {
            image.gameObject.SetActive(true);
            image.sprite = noCluesLeft;
        }
        else if(count > 0 && FirstPersonController.instance.playerState == FirstPersonController.PlayerState.Interacting)
        {
            updateCurrentClue(currentCollider);
            image.gameObject.SetActive(true);
            image.sprite = cluesLeft;
        }
        else
        {
            image.gameObject.SetActive(false);
        }
    }
}
