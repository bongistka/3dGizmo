using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public Transform parent;

    void Awake()
    {
        parent = transform.parent;
    }

    public void ResetParent()
    {
        transform.parent = parent;
    }
}
