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
        Notification.instance.newMysteryNotification(); // Call newMystery notification to bring up notification
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
        }

        if (clue.timeline == Enum.Timeline.Past) pastClueCount++;
        if (pastClueCount == 6) sixPastClues.Raise();

        if (clue.name.Contains("Leather")) leatherBookCount++;
        if (leatherBookCount == 2) secondLeatherBook.Raise();
        if (leatherBookCount == 3) thirdLeatherBook.Raise();
        Notification.instance.updatedMysteryNotification(); // Call newMystery notification to bring up notification
    }

    public void RevealMysteryEntry(MysteryEntry e)
    {
        if (e.Complete)
        {
            if (e.revealed == false)
            {
                Debug.Log("New Entries!");
            }
            e.revealed = true;
        }
        Notification.instance.solvedMysteryNotification(); // Call newMystery notification to bring up notification
    }
}
