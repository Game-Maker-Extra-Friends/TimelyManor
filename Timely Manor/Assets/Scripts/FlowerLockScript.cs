using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLockScript : MonoBehaviour
{
    public GameObject boxOpen;
    public GameObject boxBookTaken;

    public LockTumbler tumblerA;
    public LockTumbler tumblerB;
    public LockTumbler tumblerC;

    public void CheckSolution()
    {
        if (tumblerA.flowerIndex == 1 && tumblerB.flowerIndex == 0 && tumblerC.flowerIndex == 0)
        {
            OpenBox();
        }
    }

    public void OpenBox()
    {
        boxOpen.SetActive(true);
        FindObjectOfType<WoodenBoxScript>().OpenBox();
    }

    public void TakeBook()
    {
        FindObjectOfType<WoodenBoxScript>().TakeBook();
    }
}
