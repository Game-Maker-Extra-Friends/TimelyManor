using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MysteryEntry
{
    public bool eventBased;
    public bool allRequired;
    public string text;
    public List<Clue> clueTriggers;
    public List<GameEvent> eventTriggers;
    public int triggersMet;
    public bool revealed;

    public bool Complete
    {
        get
        {
            if (eventBased || !allRequired) return triggersMet > 0;
            return clueTriggers.Count == triggersMet;
        }
    }

    public void CheckTriggers(GameEvent evt)
    {
        if (eventBased && eventTriggers.Contains(evt))
        {
            triggersMet++;
        }
    }

    public void CheckTriggers(Clue clue)
    {

        if (!eventBased && clueTriggers.Contains(clue))
        {
            triggersMet++;
        }
    }
}
