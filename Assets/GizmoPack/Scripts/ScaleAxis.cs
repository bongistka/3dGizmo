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
        GetComponent<Renderer>().material = materialData.highlightMaterial;
        axisScaleObject.GetComponent<Renderer>().material = materialData.highlightMaterial;
    }

    protected override void ReleaseHoverMaterial()
    {
        switch (axis)
        {
            case GizmoAxis.xAxis:
                GetComponent<Renderer>().material = materialData.xMaterial;
                axisScaleObject.GetComponent<Renderer>().material = materialData.xMaterial;
                break;
            case GizmoAxis.yAxis:
                GetComponent<Renderer>().material = materialData.yMaterial;
                axisScaleObject.GetComponent<Renderer>().material = materialData.yMaterial;
                break;
            case GizmoAxis.zAxis:
                GetComponent<Renderer>().material = materialData.zMaterial;
                axisScaleObject.GetComponent<Renderer>().material = materialData.zMaterial;
                break;
        }
    }

    public override void ResetGizmo()
    {
        root.transform.localScale = Vector3.one;
        foreach (GameObject controlledObject in gizmoController.controlledObjects)
            controlledObject.transform.localScale = Vector3.one;
    }
}
