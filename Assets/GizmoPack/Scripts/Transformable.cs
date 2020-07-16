using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformable : MonoBehaviour
{
    public GameObject transformGizmo;
    public GameObject scaleGizmo;
    public GameObject rotateGizmo;
    private GameObject currentGizmo;
    private GizmoController gizmoController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            InitGizmo(transformGizmo, this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            InitGizmo(rotateGizmo, this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitGizmo(scaleGizmo, this.gameObject);
        }
    }

    private void InitGizmo(GameObject gizmoObject, GameObject controlledObject)
    {
        Destroy(currentGizmo);
        currentGizmo = GameObject.Instantiate(gizmoObject, transform.position, transform.rotation);
        gizmoController = currentGizmo.GetComponent<GizmoController>();
        gizmoController.controlledObjects = new GameObject[1];
        gizmoController.controlledObjects[0] = controlledObject;
    }
}
