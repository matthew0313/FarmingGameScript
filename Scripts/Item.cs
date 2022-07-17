using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Item : MonoBehaviour
{
    public class ToolAction : UnityEvent{};
    public bool HoldAction = false;
    public bool IndicateLand = false;
    public bool Consumed = false;
    public GameObject InstantiatingModel;
    public PlayerActions PlayerActions;
    public PlayerAnimations PlayerAnimations;
    public PlayerInventory PlayerInventory;
    public int thisItemSlot;
    [SerializeField] Tfunc ActionType;
    public ToolAction action = new ToolAction();

    public void Begin(){
        int a = 0;
        if(IndicateLand) PlayerActions.Indicate = true;
        foreach(Tfunc t in Enum.GetValues(typeof(Tfunc))){
            if(PlayerActions.Actions[a]==null) Debug.Log("EEEEEEE");
            if((ActionType & t)>0){
                action.AddListener(PlayerActions.Actions[a]);
            }
            a++;
        }
    }
    void Update(){
        if(action!=null){
            if(HoldAction&&Input.GetMouseButton(0)){
                if(InstantiatingModel!=null){
                    PlayerActions.InstantiateModel = InstantiatingModel;
                }
                action.Invoke();
            }
            else if(HoldAction==false&&Input.GetMouseButtonDown(0)){
                if(InstantiatingModel!=null){
                    PlayerActions.InstantiateModel = InstantiatingModel;
                }
                action.Invoke();
            }
        }
    }
}
[System.Serializable, System.Flags] public enum Tfunc{
    Tilling = 1<<0
}

