using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MysteryUI : MonoBehaviour
{
    public GameObject mysteryPrefab;
    public GameObject mysteryEntryPrefab;
    public GameObject pageRulePrefab;
    public Transform scrollContainer;
    public Transform mysteryEntryContainer;

    private void OnEnable()
    {
        foreach (Transform t in scrollContainer)
        {
            Destroy(t.gameObject);
        }
        foreach (Mystery m in Resources.LoadAll("Mysteries")) {
            if (m.entries.Where(x => x.Complete).Any())
            {
                MysteryItem instance = Instantiate(mysteryPrefab, scrollContainer).GetComponent<MysteryItem>();
                instance.Set(m, this);
            }
        }
    }

    public void UpdateUI(Mystery m)
    {
        Debug.Log("setting inspector");
        foreach (Transform t in mysteryEntryContainer)
        {
            Destroy(t.gameObject);
        }
        foreach (MysteryEntry e in m.entries)
        {
            if (e.revealed)
            {
                var script = Instantiate(mysteryEntryPrefab, mysteryEntryContainer).GetComponent<MysteryEntryUI>();
                script.Set(e);
                Instantiate(pageRulePrefab, mysteryEntryContainer);
            }
        }
        if (mysteryEntryContainer.childCount == 0)
        {
            
            return;
        }
        Destroy(mysteryEntryContainer.GetChild(mysteryEntryContainer.childCount - 1).gameObject);
    }
}
