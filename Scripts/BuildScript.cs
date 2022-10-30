using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    [SerializeField] float gridSize;
    [SerializeField] float yHeight;
    [SerializeField] float BuildReach;
    [SerializeField] GameObject Grid;
    [SerializeField] LayerMask[] WhatToHit;
    public bool BuildMode;
    Building BuildingObject;
    GameObject PlaceModel;
    [SerializeField] Building test;
    void Start(){
        StartBuild(test);
    }
    public void StartBuild(Building Object){
        BuildMode = true;
        BuildingObject = Object;
        PlaceModel = Instantiate(BuildingObject.PlaceModel);
    }
    void Update(){
        if(BuildMode){
            Ray h = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(h.origin, h.direction, out hit, BuildReach, WhatToHit[0])){
                PlaceModel.transform.position = new Vector3(Mathf.Round(hit.point.x*(1.0f/gridSize))/(1.0f/gridSize), yHeight, Mathf.Round(hit.point.z*(1.0f/gridSize))/(1.0f/gridSize));
            }
            else{
                PlaceModel.transform.position = h.origin+h.direction*BuildReach;
            }
            if(Input.GetKeyDown(KeyCode.R)){
                PlaceModel.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f), Space.World);
            }
            if(Input.GetKeyDown(KeyCode.T)){
                PlaceModel.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f), Space.World);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                if(Input.GetKey(KeyCode.LeftShift)){
                    yHeight += gridSize*10.0f;
                }
                else yHeight += gridSize;
            }
            if(Input.GetKeyDown(KeyCode.Q)){
                if(Input.GetKey(KeyCode.LeftShift)){
                    yHeight -= gridSize*10.0f;
                }
                else yHeight -= gridSize;
            }
            Grid.transform.position = new Vector3(0.0f, yHeight, 0.0f);
            if(Input.GetMouseButtonDown(0)){
            
            }
        }
    }
}
[System.Serializable] public struct Building{
    public GameObject Model;
    public GameObject PlaceModel;
    public Vector3 Collider;
    public int Cost;
}
