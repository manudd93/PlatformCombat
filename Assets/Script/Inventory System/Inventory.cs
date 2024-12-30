using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory 
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemlist;
    private Action<Item> UseItemAction;


    public Inventory(Action<Item> UseItemAction){
        itemlist=new List<Item>();
        this.UseItemAction=UseItemAction;
        AddItem(new Item{itemType=Item.ItemType.healtPotion,amount =1});
       
        Debug.Log(itemlist.Count);
        
    }
    public void AddItem(Item item){
        if(item.isStackable()){
            bool isAlredyInInventory=false;
foreach(Item inventoryItem in itemlist){
    if(inventoryItem.itemType==item.itemType){
        inventoryItem.amount +=item.amount;
        isAlredyInInventory=true;
        
    }

}
if(!isAlredyInInventory){
      itemlist.Add(item);
}
        }else{
             itemlist.Add(item);
        }
       
        OnItemListChanged?.Invoke(this,EventArgs.Empty);
    }
    public List<Item> GetItemList(){
        return itemlist;
        
    }
    public void RemoveItem(Item item){
    
        if(item.isStackable()){
            Item itemInInventory=null;
foreach(Item inventoryItem in itemlist){
    if(inventoryItem.itemType==item.itemType){
        inventoryItem.amount -=item.amount;
        itemInInventory=inventoryItem;
    }

}
if(itemInInventory !=null && itemInInventory.amount <=0){
      itemlist.Remove(itemInInventory);
}
        }else{
             itemlist.Remove(item);
        }
       
        OnItemListChanged?.Invoke(this,EventArgs.Empty);
    }

    public void UseItem(Item Item){
UseItemAction(Item);

    }
    }
