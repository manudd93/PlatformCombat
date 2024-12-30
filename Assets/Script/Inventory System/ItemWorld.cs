using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private TextMeshPro textMesh;
    private SpriteRenderer spriteRenderer;
  public void SetItem(Item item){
      this.item=item;
      spriteRenderer.sprite=item.GetSprite();
    if(item.amount>1){
      textMesh.SetText(item.amount.ToString());
    }else{
      textMesh.SetText("");
    }
  }
  public static ItemWorld SpawnItemWorld(Item item ,Vector3 position){
     Transform transform =Instantiate(ItemAssets.Instance.pfItemWord,position,Quaternion.identity);
     ItemWorld itemWorld=transform.GetComponent<ItemWorld>();
     itemWorld.SetItem(item);
     

     return itemWorld;
  }
  void Awake(){
spriteRenderer=GetComponent<SpriteRenderer>();
textMesh=transform.Find("TextMeshPro").GetComponent<TextMeshPro>();
  }
  public Item GetItem(){
return item;
  }
  public void DestroySelf(){
    Debug.Log("ook");
    Destroy(gameObject);
  }

  public static ItemWorld DropItem(Vector3 position,Item item){
    Vector3 RandomDir=Vector2.up;
  ItemWorld itemWorld=  SpawnItemWorld(item,position+RandomDir*5f);
  itemWorld.GetComponent<Rigidbody2D>().AddForce(RandomDir*5f,ForceMode2D.Impulse);
  return itemWorld;
  }
}
