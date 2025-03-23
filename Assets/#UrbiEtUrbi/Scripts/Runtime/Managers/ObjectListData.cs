using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectList", menuName = "Level/Object List")]
public class ObjectListData : ScriptableObject
{
    public List<ObjectData> objects;

    public float Density;
}

[System.Serializable]
public class ObjectData
{
    public string name;
    public GameObject prefab;
    public float width;
    public float height;
}