using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsManager : MonoBehaviour
{
    public List<Building> UnlockedBuildings = new List<Building>();
    public Building[] StarterBuildings;
    [SerializeField] GameObject[] Parents;
    [SerializeField] List<List<GameObject>> Buttons = new List<List<GameObject>>();
    [SerializeField] GameObject BuildButton;
    [SerializeField] BuildMenu M_BuildMenu;
    void Start(){
        for(int i = 0 ; i < Parents.Length ; i++){
            Buttons.Add(new List<GameObject>());
        }
        for(int i = 0 ; i < StarterBuildings.Length ; i++){
            ButtonUpdate(true, StarterBuildings[i]);
        }
    }
    public void ButtonUpdate(bool indicateNew, Building Build){
        GameObject a = Instantiate(BuildButton);
        a.transform.GetChild(0).GetComponent<Text>().text = Build.Name;
        a.transform.GetChild(1).GetComponent<Image>().sprite = Build.Picture;
        a.transform.SetParent(Parents[(int)Build.Type].transform);
        a.transform.localPosition = new Vector3(0.0f + Buttons[(int)Build.Type].Count%7*150.0f, 0.0f + Buttons[(int)Build.Type].Count/7*150.0f, 0.0f);
        Buttons[(int)Build.Type].Add(a);
        UnlockedBuildings.Add(Build);
        BuildMenuButton b = a.GetComponent<BuildMenuButton>();
        b.New = indicateNew;
        b.AssignedBuild = Build;
        b.M_BuildMenu = M_BuildMenu;
        b.CheckNew();
    }
}
[System.Serializable] public struct Building{
    public string Name;
    public string Description;
    public GameObject Model;
    public BuildingType Type;
    public int Price;
    public Item[] Ingredients;
    public Sprite Picture;
}
[System.Serializable] public enum BuildingType{
    Mine,
    Processor,
    Seller,
    Storage,
    Electricity,
    Misc
}