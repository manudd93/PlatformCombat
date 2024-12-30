using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ItemSelection : MonoBehaviour
{
    public Image SelectionImage;
    public List<Sprite> ItemList = new List<Sprite>();
    private int ItemSpot=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RightSelection(){
        if(ItemSpot<ItemList.Count-1){
          ItemSpot++;
          SelectionImage.sprite = ItemList[ItemSpot];  
        }

    }

    public void LeftSelection(){
if(ItemSpot>0){
          ItemSpot--;
          SelectionImage.sprite = ItemList[ItemSpot];  
        }
    }
    
}
