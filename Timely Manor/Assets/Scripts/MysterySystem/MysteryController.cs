using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryController : MonoBehaviour
{
    public List<Mystery> mysteries;

    // Start is called before the first frame update
    void Start()
    {
        ClueScript.ClueInteract += UpdateMysteries;
    }

    private void UpdateMysteries(Clue clue)
    {
        foreach (Mystery m in mysteries)
        {
            foreach (MysteryEntry e in m.entries)
            {
                if (e.triggers.Contains(clue))
                {
                    e.revealed = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
