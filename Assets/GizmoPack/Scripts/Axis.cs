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

    protected void InitAxis()
    {
        scaleToViewpoint = transform.parent.parent.GetComponent<ScaleToViewpoint>();
        root = scaleToViewpoint.transform.parent.gameObject;
        gizmoController = root.GetComponent<GizmoController>();
    }

    protected void StartMouseDrag()
    {
        gizmoController.InitializeController();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = scaleToViewpoint.distanceFromCamera;
        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    protected Vector3 UpdateMouseDrag(Vector3 mousePos, out Vector3 delta, out Vector3 pos)
    {
        mousePos.z = scaleToViewpoint.distanceFromCamera;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        delta = worldPosition - lastMousePos;
        pos = transform.position;
        return mousePos;
    }
}
