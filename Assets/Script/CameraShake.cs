using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
public GameObject player;
public Vector3 OriginalPos;
 
public IEnumerator Shake(float duration,float magnitude){


float elapsed=0.0f;
while(elapsed <duration){
    float x=Random.Range(transform.position.x-1f,transform.position.x+1f)*magnitude;
       float y=Random.Range(transform.position.y-1f,transform.position.y+1f)*magnitude;
transform.localPosition=new Vector3(x,y,-10);
elapsed +=Time.deltaTime;
yield return null;
}

//transform.localPosition=new Vector3(OriginalPos.x,OriginalPos.y,-10);
}



void Update(){
       // OriginalPos= player.transform.localPosition;
    if(Input.GetKeyDown(KeyCode.H)){
        StartCoroutine(Shake(.25f,0.1f));
    }
}
}
