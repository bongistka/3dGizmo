using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAxis : Axis
{
    // Start is called before the first frame update
    void Start()
    {
        InitAxis();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        StartMouseDrag();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 delta, pos;
        mousePos = UpdateMouseDrag(mousePos, out delta, out pos);

        switch (axis)
        {
            case GizmoAxis.xAxis:
                pos.x += delta.x;
                break;
            case GizmoAxis.yAxis:
                pos.y += delta.y;
                break;
            case GizmoAxis.zAxis:
                pos.z += delta.z;
                break;
        }

        transform.position = pos;

        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        gizmoController.ReleaseController();
    }
}
