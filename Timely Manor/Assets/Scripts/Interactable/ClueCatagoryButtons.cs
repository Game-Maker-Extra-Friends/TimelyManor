using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueCatagoryButtons : MonoBehaviour
{
    //public Enum.Timeline timeline = Enum.Timeline.Present;
    //public string currentTimelineString = "Present";
    public string currentLocationString = "LivingRoom";
    public Transform currentFilterTransform;

    public Transform[] slots;

    public void ChangeLocation(string locationStr)
    {
        currentLocationString = locationStr;
        currentFilterTransform.gameObject.SetActive(false);
        Debug.Log("ClueSlotGroup" + locationStr);
        findCorrectTransformLocation(locationStr);
        currentFilterTransform.gameObject.SetActive(true);
    }
    //public void ChangeTimeline(string timelineStr)
    //{
    //    currentTimelineString = timelineStr;
    //    currentFilterTransform.gameObject.SetActive(false);
    //    findCorrectTransformTimeline(timelineStr);
    //    currentFilterTransform.gameObject.SetActive(true);
    //}

    void findCorrectTransformLocation(string locationStr)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (("ClueSlotGroup" + locationStr) == slots[i].transform.name)
            {
                currentFilterTransform = slots[i];
                break;
            }
        }
    }

    //void findCorrectTransformTimeline(string timelineStr)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (("ClueSlotGroup" + timelineStr + currentLocationString) == slots[i].transform.name)
    //        {
    //            currentFilterTransform = slots[i];
    //            break;
    //        }
    //    }
    //}
}
