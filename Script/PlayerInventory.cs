using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> Inventory = new List<Item>();
    [SerializeField] RectTransform addIndicatorPositioner;
    [SerializeField] GameObject addIndicator;
    [SerializeField] int maxIndicators;
    [SerializeField] float IndicatorRemoveTime = 3.0f;
    [SerializeField] List<GameObject> Indicators = new List<GameObject>();
    [SerializeField] Item TestItem;
    [SerializeField] int IndicatorCount = 0;
    float IndicatorRemoveTmp;
    public void IndicatorRemove(){
        IndicatorRemoveTmp = 0.0f;
        GameObject r = Indicators[0];
        Indicators.Remove(Indicators[0]);
        Destroy(r);
        IndicatorCount--;
        for(int i = 0 ; i < IndicatorCount ; i++){
            RectTransform e = Indicators[i].GetComponent<RectTransform>();
            e.localPosition = new Vector3(0, e.localPosition.y-50.0f, 0);
        }
    }
    void Update(){
        if(IndicatorCount>0){
            IndicatorRemoveTmp += Time.deltaTime;
            if(IndicatorRemoveTmp>=IndicatorRemoveTime) IndicatorRemove();
        }
        if(Input.GetKeyDown((KeyCode)(97))){
            Debug.Log('e');
            AddItem(TestItem);
        }
    }
    public void AddItem(Item A){
        bool exist = false;
        for(int i = 0 ; i < Inventory.Count ; i++){
            if(A.ItemName == Inventory[i].ItemName){
                exist = true;
                Item e;
                e.ItemName = Inventory[i].ItemName;
                e.Amount = Inventory[i].Amount + A.Amount;
                Inventory[i] = e;
                break;
            }
        }
        if(exist==false){
            Inventory.Add(A);
        }
        GameObject r = Instantiate(addIndicator);
        if(IndicatorCount >= maxIndicators){
            IndicatorRemove();
        }
        r.transform.SetParent(addIndicatorPositioner);
        r.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 50.0f*IndicatorCount, 0.0f);
        r.GetComponent<Text>().text = "+" + A.Amount + " " + A.ItemName.ToString();
        Indicators.Add(r);
        IndicatorCount++;
    }
}
[System.Serializable] public struct Item{
    public ItemList ItemName;
    public int Amount;
}
[System.Serializable] public enum ItemList{
    Stone
}