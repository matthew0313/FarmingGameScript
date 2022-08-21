using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float CameraSpeed;
    [SerializeField] float MoveSpeed;
    [SerializeField] float HeightMoveSpeed;
    public bool canMove = true;
    void Update(){
        if(Input.GetMouseButton(1)){
            transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Mouse X")*CameraSpeed, 0);
            transform.eulerAngles += new Vector3(Input.GetAxisRaw("Mouse Y")*CameraSpeed*-1, 0, 0);
            Debug.Log(transform.eulerAngles.x + " " + transform.rotation.x);
        }
        if(canMove){
            int e = 0;
            if(Input.GetKey(KeyCode.E)) e += 1;
            if(Input.GetKey(KeyCode.Q)) e -= 1;
            transform.position = new Vector3(transform.position.x, transform.position.y + HeightMoveSpeed*Time.deltaTime*e, transform.position.z);
            Vector3 dir = transform.forward*Input.GetAxis("Vertical");
            dir += transform.right*Input.GetAxis("Horizontal");
            dir.y = 0.0f;
            dir.Normalize();
            transform.position += dir*MoveSpeed*Time.deltaTime;
        }
    }
}
