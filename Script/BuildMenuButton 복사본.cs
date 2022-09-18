using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuButton : MonoBehaviour
{
    public BuildMenu M_BuildMenu;
    public Building AssignedBuild;
    public bool New;
    [SerializeField] Color32 NormalColor;
    [SerializeField] Color32 NewColor;
    [SerializeField] GameObject NewIndicator;
    [SerializeField] Image Self;
    public void CheckNew(){
        if(New){
            NewIndicator.SetActive(true);
            Self.color = NewColor;
        }
        else{
            NewIndicator.SetActive(false);
            Self.color = NormalColor;
        }
    }
    public void MenuOpenCall(){
        M_BuildMenu.SideMenu(AssignedBuild);
        if(New) New = false;
        CheckNew();
    }
}
