using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScan : MonoBehaviour
{
    [SerializeField] float Reach;
    [SerializeField] LayerMask WhatToHit;
    public Transform Chosen = null;
    void Update(){
        Ray h = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(h.origin, h.direction, out hit, Reach, WhatToHit)){
            Chosen = hit.transform;
            Chosen.parent.parent.GetComponent<Outline>().enabled = true;
        }
        else{
            if(Chosen!=null){
                Chosen.parent.parent.GetComponent<Outline>().enabled = false;
            }
            Chosen = null;
        }
    }
}
