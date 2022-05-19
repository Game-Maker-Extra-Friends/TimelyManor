using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    #region Singleton

    private static CursorController _instance;

    public static CursorController Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public Texture2D cursorTexture, cursorTexture2;

    public void defaultCursor()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
    }

    public void clueCursor()
    {
        Cursor.SetCursor(cursorTexture2, new Vector2(0, 0), CursorMode.Auto);
    }
}
