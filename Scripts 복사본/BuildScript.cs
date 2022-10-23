using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    [SerializeField] float gridSize;
    [SerializeField] float yHeight;
    public bool BuildMode;
    Building BuildingObject;
    public void StartBuild(Building Object){

    }
    void Update(){
        if(BuildMode){
            
        }
    }
}
[System.Serializable] public struct Building{
    public GameObject Model;
    public int Cost;
}
