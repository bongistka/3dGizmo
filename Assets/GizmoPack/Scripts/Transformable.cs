using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformable : MonoBehaviour
{
    private GizmoData gizmoData;
    private GameObject currentGizmo;
    private GizmoController gizmoController;

    // Start is called before the first frame update
    void Start()
    {
        gizmoData = Resources.Load<GizmoData>("ScriptableObjects/GizmoData");
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
    }
}
