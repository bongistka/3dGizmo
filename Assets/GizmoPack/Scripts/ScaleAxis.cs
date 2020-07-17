using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAxis : Axis
{
    private Vector3 startPosition;
    private Transform axisScaleObject;
    private float axisLength = 0.01f;

    void Awake()
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
        base.UpdateHoverMaterial();
        axisScaleObject.GetComponent<Renderer>().material = materialData.highlightMaterial;
    }

    protected override void ReleaseHoverMaterial()
    {
        base.ReleaseHoverMaterial();
        switch (axis)
        {
            case GizmoAxis.xAxis:
                axisScaleObject.GetComponent<Renderer>().material = materialData.xMaterial;
                break;
            case GizmoAxis.yAxis:
                axisScaleObject.GetComponent<Renderer>().material = materialData.yMaterial;
                break;
            case GizmoAxis.zAxis:
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

    public override void DisableAxis()
    {
        axisScaleObject.GetComponent<Renderer>().material = materialData.frozenMaterial;
        base.DisableAxis();
    }
}
