using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDir : MonoBehaviour
{
   public bool Flipped=false;
    float speed=30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Flipped==true){
Flip();
        }
        transform.Translate(new Vector3(1f*speed*Time.deltaTime,0f,0f));

    

        Destroy(this.gameObject,5f);
    }

    public void Flip(){
    Debug.Log("flippato");
        Flipped=!Flipped;

        transform.Rotate(0f,180f,0f);
    }

}
