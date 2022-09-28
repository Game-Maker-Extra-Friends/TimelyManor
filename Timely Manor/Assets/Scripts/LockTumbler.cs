using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockTumbler : MonoBehaviour
{
    public Image icon;
    public List<Sprite> flowers;
    public int flowerIndex;

    public void Start()
    {
        icon.sprite = flowers[flowerIndex];
    }

    public void ChangeLockIcon()
    {
        flowerIndex++;
        if (flowerIndex >= flowers.Count)
        {
            flowerIndex = 0;
        }
        icon.sprite = flowers[flowerIndex];

        SendMessageUpwards("CheckSolution");
    } 
}
