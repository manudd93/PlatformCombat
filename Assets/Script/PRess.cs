using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRess : MonoBehaviour
{
    public float timer=5f;
bool stopTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTime){
             timer-=Time.deltaTime;
        }
       
        if(timer<=0){
            stopTime=true;
        }
        if(!stopTime && Input.GetMouseButtonDown(0)){
            timer=5f;
        }

        if(Input.GetKeyDown(KeyCode.Y)){
            ItemWorld.SpawnItemWorld(new Item{itemType=Item.ItemType.healtPotion,amount=1},new Vector3(0.6f,-2.4f,0f));
             

        }
    }
}
