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

    private void OnMouseDown()
    {
        startPosition = transform.position;
        StartMouseDrag();
    }

    private void OnMouseDrag()
    {
        scale = axisScaleObject.localScale;
        UpdateMouseDrag();

        dist = transform.localPosition.y - axisScaleObject.transform.localPosition.y;
        scaleFactor = dist / axisLength;
        scale.y = scaleFactor;

        transform.position = pos;
        axisScaleObject.localScale = scale;

        UpdateParentScale(scaleFactor);

        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        gizmoController.ReleaseController();
        ReleaseHoverMaterial();
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

    protected override void UpdateHoverMaterial()
    {
        lastMaterial = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = hoverMaterial;
        axisScaleObject.GetComponent<Renderer>().material = hoverMaterial;
    }

    protected override void ReleaseHoverMaterial()
    {
        GetComponent<Renderer>().material = lastMaterial;
        axisScaleObject.GetComponent<Renderer>().material = lastMaterial;
    }
}
