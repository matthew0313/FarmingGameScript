using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField] float MoveSpeed;
    [SerializeField] float CameraSpeed;
    [SerializeField] Transform CamPivot;
    Rigidbody Rigidbody;
    void Start(){
        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update(){
        Vector3 dir = Vector3.zero;
        dir += Vector3.forward*Input.GetAxisRaw("Vertical");
        dir += Vector3.right*Input.GetAxisRaw("Horizontal");
        dir = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one).MultiplyPoint(dir);
        if(dir.sqrMagnitude > 1.0f) dir.Normalize();
        if(canMove) Rigidbody.MovePosition(transform.position + dir * MoveSpeed * Time.deltaTime);
        if(Input.GetMouseButton(1)){
            transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Mouse X")*CameraSpeed, 0);
            CamPivot.eulerAngles += new Vector3(Input.GetAxisRaw("Mouse Y")*CameraSpeed*-1, 0, 0);
            Debug.Log(CamPivot.eulerAngles.x + " " + CamPivot.rotation.x);
            Mathf.Clamp(CamPivot.rotation.x, -0.4f, 0.4f);
        }
    }
    public void DisableMovement(){
        canMove = false;
    }
    public void EnableMovement(){
        canMove = true;
    }

}
