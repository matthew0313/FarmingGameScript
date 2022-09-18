using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] GameObject SidePanel;
    [SerializeField] Image SideImage;
    [SerializeField] Text SideName;
    [SerializeField] Text SideDescription;
    [SerializeField] Text SideOperation;
    [SerializeField] Text SideIngredients;
    [SerializeField] Material SampleMaterial;
    [SerializeField] CanvasGroup menu;
    Building CurrentChosen;
    GameObject Sample;
    bool BuildMode = false;
    void Update(){
        if(BuildMode){
            Vector3 MousePos = Input.mousePosition;
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
            Sample.transform.position = new Vector3((float)Mathf.Round(WorldPos.x), 1.0f, (float)Mathf.Round(WorldPos.z));
            if(Input.GetKeyDown((KeyCode)82)){
                Sample.transform.rotation = Quaternion.Euler(new Vector3(0.0f, (Sample.transform.rotation.y + 90.0f)%360.0f, 0.0f));
            }
            if(Input.GetMouseButtonDown(0)){
                GameObject a = Instantiate(CurrentChosen.Model, Sample.transform.position, Sample.transform.rotation);
                Destroy(Sample);
            }
        }
    }
    public void SideMenu(Building Build){
        CurrentChosen = Build;
        SideImage.sprite = Build.Picture;
        SideName.text = Build.Name;
        SideDescription.text = Build.Description;
        BuildingScript a = Build.Model.GetComponent<BuildingScript>();
        SideOperation.text = "Operation Time: " + a.OperationTime + "s\nElectricity Use: " + a.ElectricityUse;
        SideIngredients.text = "Ingredients: $" + Build.Price.ToString() + ",";
        for(int i = 0 ; i < Build.Ingredients.Length ; i++){
            SideIngredients.text += " " + Build.Ingredients[i].ItemName.ToString() + " x " + Build.Ingredients[i].Amount + ",";
        }
        SidePanel.SetActive(true);
    }
    public void Build(){
        menu.alpha = 0;
        menu.interactable = false;
        Sample = Instantiate(CurrentChosen.Model);
        for(int i = 0 ; i < Sample.transform.childCount ; i++){
            Sample.transform.GetChild(i).GetComponent<MeshRenderer>().materials[0] = SampleMaterial;
        }
        BuildMode = true;
    }
}
