using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAxis : Axis
{
    private Vector3 startPosition;
    private Transform axisScaleObject;
    private float axisLength = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        InitAxis();
        axisScaleObject = transform.parent.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        startPosition = transform.position;
        StartMouseDrag();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 delta, pos;
        mousePos = UpdateMouseDrag(mousePos, out delta, out pos);
        Vector3 scale = axisScaleObject.localScale;

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

        float dist = transform.localPosition.y - axisScaleObject.transform.localPosition.y;
        float scaleFactor = dist / axisLength;
        scale.y = scaleFactor;

        transform.position = pos;
        axisScaleObject.localScale = scale;

        UpdateParentScale(scaleFactor);

        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        gizmoController.ReleaseController();
        transform.position = startPosition;
        axisScaleObject.localScale = Vector3.one;
        gizmoController.gizmoParent.transform.localScale = Vector3.one;
    }

    private void UpdateParentScale(float scaleFactor)
    {
        Vector3 scale = gizmoController.gizmoParent.transform.localScale;

        switch (axis)
        {
            case GizmoAxis.xAxis:
                scale.x = scaleFactor;
                break;
            case GizmoAxis.yAxis:
                scale.y = scaleFactor;
                break;
            case GizmoAxis.zAxis:
                scale.z = scaleFactor;
                break;
        }
        
        gizmoController.gizmoParent.transform.localScale = scale;
    }
}
