using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoController : MonoBehaviour
{
    public GameObject[] controlledObjects;
    public bool isGlobal;
    [HideInInspector] public Transform gizmoParent;
    private GameObject root;
    private Axis axis;

    // Start is called before the first frame update
    void Start()
    {
        gizmoParent = transform.Find("Parent");
        axis = transform.GetChild(0).GetChild(1).GetComponentInChildren<Axis>();
    }

    public void InitializeController()
    {
        foreach (GameObject controlledObject in controlledObjects)
        {
            controlledObject.AddComponent<ObjectInfo>();
            controlledObject.transform.parent = gizmoParent;
        }
    }

    public void ReleaseController()
    {
        foreach (GameObject controlledObject in controlledObjects)
        {
            ObjectInfo objectInfo = controlledObject.GetComponent<ObjectInfo>();
            objectInfo.ResetParent();
            Destroy(objectInfo);
        }
    }

    public void ResetGizmo()
    {
        axis.ResetGizmo();
    }
}
