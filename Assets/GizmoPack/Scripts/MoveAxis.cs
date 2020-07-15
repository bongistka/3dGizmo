using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxis : Axis
{
    private Vector3 lastMousePos;

    [HideInInspector]
    public GameObject root;

    private ScaleToViewpoint scaleToViewpoint;
    private GizmoController gizmoController;

    // Start is called before the first frame update
    void Start()
    {
        scaleToViewpoint = transform.parent.parent.GetComponent<ScaleToViewpoint>();
        root = scaleToViewpoint.transform.parent.gameObject;
        gizmoController = root.GetComponent<GizmoController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gizmoController.InitializeController();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = scaleToViewpoint.distanceFromCamera;
        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = scaleToViewpoint.distanceFromCamera;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 delta = worldPosition - lastMousePos;
        Vector3 pos = transform.position;

        
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

        root.transform.position = pos;

        lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnMouseUp()
    {
        gizmoController.ReleaseController();
    }
}
