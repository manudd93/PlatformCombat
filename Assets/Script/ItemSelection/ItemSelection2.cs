using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ItemSelection2 : MonoBehaviour
{
    public GameObject Container;
    public GameManager gameManager;
    public List<GameObject> ItemList = new List<GameObject>();
    private int ItemSpot=-1;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void RightSelection(){
        if(ItemSpot<ItemList.Count-1){
          ItemSpot++;
        Debug.Log(Container.transform.childCount);
for(int i=0; i<Container.transform.childCount ;i ++){
Container.transform.GetChild(i).gameObject.SetActive(false);
Debug.Log("Triiibal");
        }
        Container.transform.GetChild(ItemSpot).gameObject.SetActive(true);
         gameManager.ChangePowerType(Container.transform.GetChild(ItemSpot).gameObject.name.ToString());
        }

    }

    public void LeftSelection(){
if(ItemSpot>0){
          ItemSpot--;
          Debug.Log(Container.transform.childCount);
for(int i=0;i < Container.transform.childCount;i ++){
Container.transform.GetChild(i).gameObject.SetActive(false);
Debug.Log("Triiibal");
        }
       Container.transform.GetChild(ItemSpot).gameObject.SetActive(true);
       gameManager.ChangePowerType(Container.transform.GetChild(ItemSpot).gameObject.name.ToString());
        }


        }
    }
    

