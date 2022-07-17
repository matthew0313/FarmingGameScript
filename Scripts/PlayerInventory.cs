using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool canSwitchEquipment = true;
    [SerializeField] Popup InventoryPopup;
    [SerializeField] Slot[] Slots = new Slot[40];
    [SerializeField] Transform EquippedItemLocator;
    [SerializeField] PlayerActions PlayerActions;
    [SerializeField] PlayerAnimations PlayerAnimations;
    [SerializeField] GameObject Equipped;
    int EquipSlot;
    int CurrentSlot = -1;
    bool chainEquip;
    void Update(){
        for(int i = 0 ; i < 10 ; i++){
            if(Input.GetKeyDown((KeyCode)(i+48)) && Slots[i+30].Info.Equippable && canSwitchEquipment){
                EquipSlot = i+30;
                if(Equipped!=null || CurrentSlot == EquipSlot){
                    PlayerAnimations.AnimationEquippedState(false);
                    if(CurrentSlot!=EquipSlot) chainEquip = true;
                }
                else PlayerAnimations.AnimationEquippedState(true);
            }
        }
    }
    public void Equip(){
        CurrentSlot = EquipSlot;
        Equipped = Instantiate(Slots[EquipSlot].Info.Model);
        Item item = Equipped.GetComponent<Item>();
        item.thisItemSlot = CurrentSlot;
        item.PlayerInventory = this;
        item.PlayerActions = PlayerActions;
        item.PlayerAnimations = PlayerAnimations;
        Equipped.transform.position = EquippedItemLocator.position;
        Equipped.transform.rotation = EquippedItemLocator.rotation;
        Equipped.transform.SetParent(EquippedItemLocator);
        item.Begin();
    }
    public void Unequip(){
        CurrentSlot = -1;
        if(PlayerActions.Indicate) PlayerActions.Indicate = false;
        Destroy(Equipped);
        if(chainEquip) PlayerAnimations.AnimationEquippedState(true);
        else enableSwitch();
    }
    public void disableSwitch(){
        canSwitchEquipment = false;
    }
    public void enableSwitch(){
        canSwitchEquipment = true;
    }
     
}
[System.Serializable] public struct Slot{
    public ItemInfo Info;
    public int Amount;
}
