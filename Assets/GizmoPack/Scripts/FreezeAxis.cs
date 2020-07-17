using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAxis : MonoBehaviour
{
    public enum GizmoType
    {
        position,
        rotation,
        scale
    };

    public GizmoType gizmoType;

    public bool freezeX;
    public bool freezeY;
    public bool freezeZ;
}
