using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    public enum GizmoAxis
    {
        xAxis,
        yAxis,
        zAxis
    };
    public GizmoAxis axis;

    protected Vector3 lastMousePos;

    [HideInInspector]
    public GameObject root;

    protected ScaleToViewpoint scaleToViewpoint;
    protected GizmoController gizmoController;

    protected Vector3 mousePos, scale, worldPosition, delta, pos;
    protected float dist, scaleFactor;


    protected virtual void InitAxis()
    {
        scaleToViewpoint = transform.parent.parent.GetComponent<ScaleToViewpoint>();
        root = scaleToViewpoint.transform.parent.gameObject;
        gizmoController = root.GetComponent<GizmoController>();
    }

    protected virtual void StartMouseDrag()
    {
        gizmoController.InitializeController();

        mousePos = Input.mousePosition;
        mousePos.z = scaleToViewpoint.distanceFromCamera;
        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    protected virtual void UpdateMouseDrag()
    {
        mousePos = Input.mousePosition;
        mousePos.z = scaleToViewpoint.distanceFromCamera;

        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        delta = worldPosition - lastMousePos;
        pos = transform.position;

        switch (axis)
        {
            case GizmoAxis.xAxis:
                pos += transform.up * delta.x;
                break;
            case GizmoAxis.yAxis:
                pos += transform.up * delta.y;
                break;
            case GizmoAxis.zAxis:
                pos += transform.up * delta.z;
                break;
        }
    }
}
