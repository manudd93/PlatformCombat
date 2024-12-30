using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using CodeMonkey.Utils;


public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   private Transform itemSlotContainer;
   private Transform itemSlotTemplate;
   private Transform player;
   public void SetInventory(Inventory inventory){
       this.inventory=inventory;
    inventory.OnItemListChanged +=Inventory_OnItemListChanged;
      RefreshInventoryItems();
   }
   private void Inventory_OnItemListChanged(object sender , System.EventArgs e){
       RefreshInventoryItems();
   }
   public void Awake(){
       itemSlotContainer=transform.Find("ItemSlotContainer");
     
       itemSlotTemplate=itemSlotContainer.Find("ItemSlotTemplate");
       
   }

   

private void RefreshInventoryItems(){
    foreach(Transform child in itemSlotContainer){
        if(child==itemSlotTemplate) continue;
Destroy(child.gameObject);
        
    }
    int x =0;
    int y=0;
    float intemSlotCellSize=80;
    foreach(Item item in inventory.GetItemList()){

RectTransform itemSlotRectTransform=Instantiate(itemSlotTemplate,itemSlotContainer).GetComponent<RectTransform>();
itemSlotRectTransform.gameObject.SetActive(true);
itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc=() =>{
    inventory.UseItem(item);
//use Item
};
itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc=() =>{
//dropItem
Item DuplicateItem=new Item {itemType=item.itemType,amount=item.amount};
inventory.RemoveItem(item);
player=GameObject.FindGameObjectWithTag("Player").transform;
ItemWorld.DropItem(player.transform.position,DuplicateItem);
};


itemSlotRectTransform.anchoredPosition=new Vector2(x*intemSlotCellSize,y*intemSlotCellSize);
Image image =itemSlotRectTransform.Find("Image").GetComponent<Image>();
image.sprite=item.GetSprite();
TextMeshProUGUI UItext=itemSlotRectTransform.Find("UpperText").GetComponent<TextMeshProUGUI>();
if(item.amount>1){
  UItext.SetText(item.amount.ToString());  
}else{
    UItext.SetText(""); 
}

x++;
if(x>=4){
    x=0;
    y++;
}

        }
}


}
