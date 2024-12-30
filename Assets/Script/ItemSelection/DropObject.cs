using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject CanvasActivate;
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag=="Player"){

            if(Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Sto Raccogliendo");
            }
          CanvasActivate.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
          CanvasActivate.gameObject.SetActive(false);
        }
    }
}
