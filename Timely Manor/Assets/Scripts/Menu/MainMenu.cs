using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Play Game Button
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quit game button
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        //Resources.Load<Save>("Saves/Save").Reset();
        ES3.DeleteDirectory("Saves/");
        Debug.Log("Save Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
