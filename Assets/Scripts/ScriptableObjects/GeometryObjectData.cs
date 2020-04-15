using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "ScriptableObjects/GeomeryObjectData", order = 1)]
public class GeometryObjectData : ScriptableObject
{
    [SerializeField]
    public List<ClickColorData> data;
}
