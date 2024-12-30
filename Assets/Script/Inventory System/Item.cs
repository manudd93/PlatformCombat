using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Item 
{
    public enum ItemType{
        sword,
        healtPotion,
        manapotion,
        coin,
        medkit,
    }
    public ItemType itemType;
    public int amount;
    
    public Sprite GetSprite(){
        switch(itemType){
            default:
            case ItemType.healtPotion : return ItemAssets.Instance.HealtPotionSprite;
            case ItemType.sword : return ItemAssets.Instance.swordSprite;
            case ItemType.manapotion : return ItemAssets.Instance.ManaPotSprite;
            case ItemType.coin : return ItemAssets.Instance.CoinSprite;
            case ItemType.medkit : return ItemAssets.Instance.MedKitSprite;
        }
    }
    public bool isStackable(){
        switch(itemType){
default:
case ItemType.coin:
case ItemType.sword: 
case ItemType.manapotion:
case ItemType.healtPotion:
return true;
case ItemType.medkit:
return false;




        }
    }
}
