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
    [HideInInspector]
    public MaterialData materialData;

    protected ScaleToViewpoint scaleToViewpoint;
    protected GizmoController gizmoController;

    protected Vector3 mousePos, scale, worldPosition, delta, pos;
    protected float dist, scaleFactor;

    private void OnMouseEnter()
    {
        if (!Input.GetMouseButton(0))
            UpdateHoverMaterial();
    }

    private void OnMouseExit()
    {
        if(!Input.GetMouseButton(0))
            ReleaseHoverMaterial();
    }

    protected virtual void InitAxis()
    {
        materialData = Resources.Load<MaterialData>("ScriptableObjects/MaterialData");
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

    protected virtual void UpdateHoverMaterial()
    {
        GetComponent<Renderer>().material = materialData.highlightMaterial;
    }

    protected virtual void ReleaseHoverMaterial()
    {
        switch (axis)
        {
            case GizmoAxis.xAxis:
                GetComponent<Renderer>().material = materialData.xMaterial;
                break;
            case GizmoAxis.yAxis:
                GetComponent<Renderer>().material = materialData.yMaterial;
                break;
            case GizmoAxis.zAxis:
                GetComponent<Renderer>().material = materialData.zMaterial;
                break;
        }
    }

    public virtual void ResetGizmo() { }

    public virtual void DisableAxis()
    {
        GetComponent<Renderer>().material = materialData.frozenMaterial;
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
        }
        enabled = false;
    }
}
