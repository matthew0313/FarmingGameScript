using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float Sensitivity;
    [SerializeField] int YReverse;
    [SerializeField] float moveSpeed;
    void Update(){
        if(Input.GetMouseButton(1)){
            Vector3 a = Camera.main.transform.eulerAngles;
            Camera.main.transform.eulerAngles = new Vector3(a.x+Input.GetAxis("Mouse Y")*Sensitivity*YReverse, a.y+Input.GetAxis("Mouse X")*Sensitivity, a.z);
        }
        Camera.main.transform.Translate(Vector3.forward*moveSpeed*Input.GetAxis("Vertical"));
        Camera.main.transform.Translate(Vector3.right*moveSpeed*Input.GetAxis("Horizontal"));
    }
}
