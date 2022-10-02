using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MysteryController : MonoBehaviour
{
    public List<Mystery> mysteries;
    public GameEvent sixPastClues;
    public GameEvent secondLeatherBook;
    public GameEvent thirdLeatherBook;

    public int pastClueCount;
    public int leatherBookCount;

    // Start is called before the first frame update
    void Start()
    {
        mysteries = Resources.LoadAll<Mystery>("Mysteries").ToList();
        ClueScript.ClueInteract += OnCluePickup;
    }

    public void OnEventRaised(GameEvent evt)
    {
        foreach (Mystery m in mysteries)
        {
            foreach (MysteryEntry e in m.entries)
            {
                e.CheckTriggers(evt);
                RevealMysteryEntry(e);
            }
        }
    }

    public void OnCluePickup(Clue clue)
    {
        foreach (Mystery m in mysteries)
        {
            foreach (MysteryEntry e in m.entries)
            {
                e.CheckTriggers(clue);
                RevealMysteryEntry(e);
            }
            if (m.Complete)
            {
                Notification.instance.solvedMysteryNotification(); // Call newMystery notification to bring up notification
            }
        }
        if (mysteries.Count == 1)
        {
            Notification.instance.newMysteryNotification(); // Call newMystery notification to bring up notification
        }

        Debug.Log(clue.timeline);
        if (clue.timeline == Enum.Timeline.Past) pastClueCount++;
        if (pastClueCount == 6) sixPastClues.Raise();

        if (clue.name.Contains("Leather")) leatherBookCount++;
        if (leatherBookCount == 2) secondLeatherBook.Raise();
        if (leatherBookCount == 3) thirdLeatherBook.Raise();
       
    }

    public void RevealMysteryEntry(MysteryEntry e)
    {
        if (e.Complete)
        {
            if (e.revealed == false)
            {
                Debug.Log("New Entries!");
                Debug.Log(Notification.instance);
                Notification.instance.updatedMysteryNotification(); // Call newMystery notification to bring up notification

            }
            e.revealed = true;
        }
    }
}
