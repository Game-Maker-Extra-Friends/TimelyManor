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
