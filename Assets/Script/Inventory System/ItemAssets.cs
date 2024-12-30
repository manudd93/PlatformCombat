using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets:MonoBehaviour
{
public static ItemAssets Instance{get;private set;}

void Awake(){
    Instance=this;
}
public Transform pfItemWord;
public Sprite HealtPotionSprite;
public Sprite swordSprite;

public Sprite ManaPotSprite;
public Sprite CoinSprite;
public Sprite MedKitSprite;
}
