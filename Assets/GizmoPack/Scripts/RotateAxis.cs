using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxis : Axis
{
    public float rotationSensitivity = 0.4f;

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
        Vector3 mousePos = Input.mousePosition;
        Vector3 delta = (mousePos - lastMousePos);
        Vector3 rotation = Vector3.zero;

        switch (axis)
        {
            case GizmoAxis.xAxis:
                rotation.x = -(delta.z + delta.y) * rotationSensitivity;
                break;
            case GizmoAxis.yAxis:
                rotation.y = -(delta.x + delta.y) * rotationSensitivity;
                break;
            case GizmoAxis.zAxis:
                rotation.z = -(delta.y + delta.y) * rotationSensitivity;
                break;
        }

        root.transform.Rotate(rotation);
        lastMousePos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        gizmoController.ReleaseController();
    }

    protected override void StartMouseDrag()
    {
        gizmoController.InitializeController();

        lastMousePos = Input.mousePosition;
    }
}
