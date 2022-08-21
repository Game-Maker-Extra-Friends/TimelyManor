using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSaves : MonoBehaviour
{
    public void DeleteSavesFolder()
    {
        ES3.DeleteDirectory("Saves/");
        Debug.Log("Saves deleted");
    }
}
