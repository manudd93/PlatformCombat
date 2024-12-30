using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    // Start is called before the first frame update
   public Item item;

   public void Start() {
       ItemWorld.SpawnItemWorld(item,transform.position);
       Destroy(gameObject);
   }
}
