using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ItemInfo[] Items;
}
[System.Serializable] public struct ItemInfo{
    public string ItemName;
    public bool Equippable;
    public bool Edible;
    public float RestoreAmount;
    public GameObject Model;
    public Sprite Icon;
    public int MaxStack;
}
