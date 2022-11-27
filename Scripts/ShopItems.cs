using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public Category[] Category;
}
public struct Item{
    public Building Build;
    public string Description;
    public string Name;
}
public struct Category{
    public (Item Item, int price)[] Items;
}