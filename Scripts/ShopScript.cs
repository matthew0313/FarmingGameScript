using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] ShopItems Items;
    [SerializeField] GameObject CategoryChooser;
    [SerializeField] GameObject ItemChooser;
    [SerializeField] Text ItemText;
    [SerializeField] GameObject ExamplePositioner;
    public bool ShoppingHere = false;
    int CurrentCategory = 0;
    int CurrentItem = 0;

    public void CategoryChoose(int c){
        CurrentCategory = c;
        GameManager.instance.Hide(CategoryChooser);
        GameManager.instance.Show(ItemChooser);
    }
    public void SetItem(){
        ItemText.text = Items.Category[CurrentCategory].Items[CurrentItem].Item.Name + "\n" + Items.Category[CurrentCategory].Items[CurrentItem].price;

    }
}
