using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxis : Axis
{
    
    // Start is called before the first frame update
    void Start()
    {
        InitAxis();
    }

    private void OnMouseDown()
    {
        StartMouseDrag();
    }

    private void OnMouseDrag()
    {
        UpdateMouseDrag();

        root.transform.position = pos;

        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        gizmoController.ReleaseController();
        ReleaseHoverMaterial();
    }
}
