using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PresentationMode
{
    Simple,
    Long,
    Interactable,
	Complex
}

[CreateAssetMenu]
public class Clue : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public PresentationMode presentationMode;

    public string description = "description";
    // Text displayed for long form clues
    public string content = "";
    // Game object for complex form clues
    public GameObject display;


    public Enum.Location location;
    public Enum.Timeline timeline;

    public bool seen;

    public bool Triggered()
    {
        return seen;
    }
}
