using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager :MonoBehaviour
{
    public static event Action ActivateIstantItem;
    PlayerStateController playerStateController;
    TrasformationManager trasformationManager;
    GameManager gameManager;
    ItemDatabase itemDatabase;
    // Start is called before the first frame update
    void Start()
    {
        GrabberItem.IstantItemPick += PickUPIstantItem;
        playerStateController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
        trasformationManager = GameObject.FindObjectOfType<TrasformationManager>();
        itemDatabase = GetComponent<ItemDatabase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PickUPIstantItem(int id)
    {

        switch (id)
        {

            case 0:
                Debug.Log("Demon Energy");
                trasformationManager.AddPower(itemDatabase.Lista_IstantItem[id].GetComponent<IstantItem>().ID_Item.value);
                break;

            case 1:
                Debug.Log("Recover Life");
                
                break;

            case 2:
                Debug.Log("other");
                break;
            case 3:
               


            case 4:
                

            case 5:

                break;


            default:

                break;
               
        }
    }
}
