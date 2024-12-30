using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootScript : MonoBehaviour
{
    public List<ItemSpawn> ListItem =new List<ItemSpawn>();
     public const int Chance=100;
    public bool AlwaysSpawnItem;
    public GameObject AlwaysItem;
    bool spwn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem()
    {

        if (AlwaysSpawnItem)
        {
            
            GameObject itemSpawning = Instantiate(AlwaysItem, this.transform.position, Quaternion.identity);
            itemSpawning.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(2,7), ForceMode2D.Impulse);
            AlwaysSpawnItem = false;


        }
    if(ListItem ==null ) {
        return;
    }
    for(int i=0;i<ListItem.Count;i++){
int rangeSpawn=Random.Range(0,Chance);
if(rangeSpawn<=ListItem[i].ChanceSpawn){
GameObject itemSpawning=Instantiate(ListItem[i].Object,this.transform.position,Quaternion.identity);
itemSpawning.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(4, 7),ForceMode2D.Impulse);
}
    }
     

        
    }
}
   [System.Serializable]
public class ItemSpawn {

 public GameObject Object;
 public int ChanceSpawn;

}
