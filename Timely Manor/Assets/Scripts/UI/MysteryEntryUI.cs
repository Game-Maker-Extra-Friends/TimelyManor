using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MysteryEntryUI : MonoBehaviour
{
    public TMP_Text content;

    public void Set(MysteryEntry e)
    {
        content.text = e.text;
    }
}
