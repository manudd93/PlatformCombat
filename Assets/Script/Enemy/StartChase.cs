using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChase : MonoBehaviour
{
    public Transform PlayerTarget;
    public float speed;
    public bool isChasing=false;

    public bool stopChase=false;
    Vector3 CurrentPosition;
    bool Flipped=false;
    public Animator anim;
 
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing==true){

stopChase=false;
transform.position=Vector2.MoveTowards(transform.position,PlayerTarget.position,speed *Time.deltaTime);
anim.SetBool("isFollowing",true);
 if(Flipped==true){
                Flip();
            }
        }
        if(stopChase==true){

            isChasing=false;
            transform.position=Vector2.MoveTowards(transform.position,CurrentPosition,speed*Time.deltaTime);
            if(transform.position==CurrentPosition){
                anim.SetBool("isFollowing",false);
                stopChase=false;
            }
 if(Flipped==true){
                Flip();
            }
        }


        if(PlayerTarget.position.x<transform.position.x){  
             if(Flipped==true){
                Flip();
            }
        }else{
             if(Flipped==false){
                Flip();
            }
        }
       /*  if(PlayerTarget.position.x<transform.position.x){    rilevare le posizioni tra player e nemico
            Debug.Log("ce lo a sinistra");
        }else{
            Debug.Log("ce lo a destra");
        }
        if(PlayerTarget.position.y>transform.position.y){
            Debug.Log("ce lo sopra");
        }
       //Debug.Log(PlayerTarget.position.x); 
       */

    }

    void Flip(){
        Flipped=!Flipped;

        transform.Rotate(0f,180f,0f);
    }
}
