using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class Mystery : ScriptableObject
{
    public string title;
    public List<MysteryEntry> entries;
    public string resolution;

    public bool Complete => GetResolution() != "";
    public string GetResolution()
    {
        if (entries.Where(x => x.revealed).Count() == entries.Count)
        {
            return resolution;
        }
        return "";
    }

    public List<MysteryEntry> GetRevealedMysteryEntries()
    {
        return entries.Where(x => x.revealed).ToList();
    }
}
