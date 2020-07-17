using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxis : Axis
{
    void Awake()
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

    public override void ResetGizmo()
    {
        root.transform.position = Vector3.zero;
        foreach (GameObject controlledObject in gizmoController.controlledObjects)
            controlledObject.transform.position = Vector3.zero;
    }
}
