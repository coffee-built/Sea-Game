using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Material,
    Crop,
    Upgrade
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public string id;
    public string displayName;
    [TextArea(15,20)]
    public string description;
    public Sprite icon;
}
