using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerActions : MonoBehaviour
{
    public GameObject Land;
    [SerializeField] PlayerAnimations PlayerAnimations;
    [SerializeField] GameObject TilledLandModel;
    public UnityAction[] Actions = new UnityAction[10];
    public bool Indicate = false;
    GameObject SetLand = null;
    void Start(){
        Actions[0] = Tilling;
    }
    public void Tilling(){
        if(Land==null || Land.GetComponent<LandScript>().occupied){
            return;
        }
        else SetLand = Land;
        PlayerAnimations.AnimationTilling();
    }
    public void AnimationTill(){
        GameObject a = Instantiate(TilledLandModel);
        a.transform.SetParent(SetLand.transform);
        a.transform.localPosition = new Vector3(0.0f, -0.6f, 0.0f);
        a.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        LandScript b = SetLand.GetComponent<LandScript>();
        b.occupied = true;
        b.landObject = a;
        b.tilledLand = a.GetComponent<TilledLand>();
    }
}
