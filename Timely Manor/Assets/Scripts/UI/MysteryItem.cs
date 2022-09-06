using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MysteryItem : MonoBehaviour
{
    public TMP_Text title;
    public Button button;
    public Mystery mystery;

    public void Set(Mystery m, MysteryUI ui)
    {
        mystery = m;
        title.text = mystery.title;
        button.onClick.AddListener(delegate() {ui.UpdateUI(mystery); });
    }
}
