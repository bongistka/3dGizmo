using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GizmoData", menuName = "Gizmo Data", order = 51)]
public class GizmoData : ScriptableObject
{
    [SerializeField]
    public GameObject transformGizmo;
    [SerializeField]
    public GameObject scaleGizmo;
    [SerializeField]
    public GameObject rotateGizmo;
}
