using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Transformable : MonoBehaviour
{
    private GizmoData gizmoData;
    private GameObject currentGizmo;
    private GizmoController gizmoController;
    private FreezeAxis[] freezeAxes = new FreezeAxis[0];

    // Start is called before the first frame update
    void Start()
    {
        gizmoData = Resources.Load<GizmoData>("ScriptableObjects/GizmoData");
        freezeAxes = GetComponents<FreezeAxis>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            InitGizmo(gizmoData.transformGizmo, this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            InitGizmo(gizmoData.rotateGizmo, this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitGizmo(gizmoData.scaleGizmo, this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentGizmo.GetComponent<GizmoController>().ResetGizmo();
        }
    }

    public void InitGizmo(GameObject gizmoObject, GameObject controlledObject)
    {
        Destroy(currentGizmo);
        currentGizmo = GameObject.Instantiate(gizmoObject, transform.position, transform.rotation);
        
        gizmoController = currentGizmo.GetComponent<GizmoController>();
        gizmoController.controlledObjects = new GameObject[1];
        gizmoController.controlledObjects[0] = controlledObject;

        SetFrozenAxes(currentGizmo);
    }

    private void SetFrozenAxes(GameObject currentGizmo)
    {
        Axis[] listOfAxes = new Axis[0];
        foreach (FreezeAxis freezeAxis in freezeAxes)
        {
            switch (freezeAxis.gizmoType)
            {
                case FreezeAxis.GizmoType.position:
                    listOfAxes = currentGizmo.GetComponentsInChildren<MoveAxis>();
                    break;
                case FreezeAxis.GizmoType.rotation:
                    listOfAxes = currentGizmo.GetComponentsInChildren<RotateAxis>();
                    break;
                case FreezeAxis.GizmoType.scale:
                    listOfAxes = currentGizmo.GetComponentsInChildren<ScaleAxis>();
                    break;
            }
            foreach(Axis axis in listOfAxes)
            {
                if (axis.axis == Axis.GizmoAxis.xAxis && freezeAxis.freezeX)
                {
                    axis.DisableAxis();
                }
                if (axis.axis == Axis.GizmoAxis.yAxis && freezeAxis.freezeY)
                {
                    axis.DisableAxis();
                }
                if (axis.axis == Axis.GizmoAxis.zAxis && freezeAxis.freezeZ)
                {
                    axis.DisableAxis();
                }
            }
        }
    }

    public void DestroyGizmo()
    {
        Destroy(currentGizmo);
    }
}
