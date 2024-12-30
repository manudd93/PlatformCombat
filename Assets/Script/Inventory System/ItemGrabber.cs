using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    Inventory inventory;

    void Awake(){
       inventory=new Inventory(UseItem);
uiInventory.SetInventory(inventory);
    }
   void OnTriggerEnter2D(Collider2D col){
       
        ItemWorld itemWorld=col.GetComponent<ItemWorld>();
       
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        
   }

   private void UseItem(Item item){
switch(item.itemType){
   case Item.ItemType.healtPotion:
Debug.Log("uso na pozione de vita");
inventory.RemoveItem(new Item{itemType=Item.ItemType.healtPotion,amount =1});
   break;
   case Item.ItemType.manapotion:
   Debug.Log("uso una pozione di mana");
inventory.RemoveItem(new Item{itemType=Item.ItemType.manapotion,amount =1});

   break;
   case Item.ItemType.medkit:
   Debug.Log("uso un fottuto medikit");
inventory.RemoveItem(new Item{itemType=Item.ItemType.medkit,amount =1});

   break;


}


   }
}
