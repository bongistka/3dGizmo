using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MaterialData", menuName = "Material Data", order = 51)]
public class MaterialData : ScriptableObject
{
    [SerializeField]
    public Material xMaterial;
    [SerializeField]
    public Material yMaterial;
    [SerializeField]
    public Material zMaterial;
    [SerializeField]
    public Material highlightMaterial;
    [SerializeField]
    public Material frozenMaterial;
}
