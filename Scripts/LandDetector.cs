using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandDetector : MonoBehaviour
{
    [SerializeField] PlayerActions PlayerActions;
    [SerializeField] GameObject Indicator;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Land"){
            if(PlayerActions.Indicate){
                Indicator.SetActive(true);
                Indicator.transform.SetParent(other.transform);
                Indicator.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else Indicator.SetActive(false);
            PlayerActions.Land = other.gameObject;
        }
        else PlayerActions.Land = null;
    }
}
