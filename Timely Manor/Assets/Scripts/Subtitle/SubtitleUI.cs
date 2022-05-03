using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SubtitleUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subtitleText = default;

    public static SubtitleUI instance;

    void Awake()
    {
        instance = this;
        ClearSubtitle();
    }

    // Update is called once per frame
    public void SetSubtitle(string subtitle, float delay)
    {
        subtitleText.text = subtitle;
        StartCoroutine(ClearAfterSeconds(delay));
    }

    public void ClearSubtitle()
    {
        subtitleText.text = "";
    }

    //Clear subtitle after audio finish playing
    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
}
