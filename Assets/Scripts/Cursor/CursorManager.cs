using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager MyInstance { get; private set; }

    [SerializeField] private List<CursorStyle> cursorStyleList;

    private CursorStyle cursorStyle;

    private int currentCursor = 0;

    public enum CursorType
    {
        Basic,
        Grab,
        Attack,
        Talk
    }

    private void Awake()
    {
        MyInstance = this;
    }

    private void Start()
    {
        SetActiveCursorType(CursorType.Basic);
    }

    public void SetActiveCursorType(CursorType cursorType)
    {
        SetActiveCursor(GetCursorStyle(cursorType));
    }

    private CursorStyle GetCursorStyle(CursorType cursorType)
    {
        foreach (CursorStyle cursorStyle in cursorStyleList)
        {
            if (cursorStyle.cursorType == cursorType)
            {
                return cursorStyle;
            }
        }
        return null;
    }

    private void SetActiveCursor(CursorStyle cursorStyle)
    {
        this.cursorStyle = cursorStyle;
        Cursor.SetCursor(cursorStyle.cursorTexture, cursorStyle.offset, CursorMode.Auto);
    }

    [System.Serializable]
    public class CursorStyle
    {
        public CursorType cursorType;
        public Texture2D cursorTexture;
        public Vector2 offset;
    }
}
