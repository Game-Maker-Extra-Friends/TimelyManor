using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    #region Singleton

    public static CursorController instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public Texture2D cursorTexture, inspectCursorTexture;

    public void defaultCursor()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void clueCursor()
    {
        Cursor.SetCursor(inspectCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
