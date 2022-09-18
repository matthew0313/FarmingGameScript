using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    
    public int price;
    public Item[] ingredient;
    [SerializeField] GameObject[] inputCollider;
    [SerializeField] GameObject[] outputPoint;
    public int ElectricityUse;
    public float OperationTime;
    public bool NoCooldown;
    public BuildIdentifier TypeScript;
    void Start(){
        TypeScript.Begin();
    }
}
[System.Serializable] public struct R{
    public Item[] Required;
    public Item[] Output;
    // Output[0] uses outputPoint[0]
}