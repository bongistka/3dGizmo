using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoController : MonoBehaviour
{
    public GameObject[] controlledObjects;
    [HideInInspector]
    public Transform gizmoParent;

    // Start is called before the first frame update
    void Start()
    {
        gizmoParent = transform.Find("Parent");
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
}
