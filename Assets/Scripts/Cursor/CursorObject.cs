using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    [SerializeField] private CursorManager.CursorType cursorType;

    private void OnMouseEnter()
    {
        CursorManager.MyInstance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        CursorManager.MyInstance.SetActiveCursorType(CursorManager.CursorType.Basic);
    }

    private void OnDestroy()
    {
        CursorManager.MyInstance.SetActiveCursorType(CursorManager.CursorType.Basic);
    }
}
