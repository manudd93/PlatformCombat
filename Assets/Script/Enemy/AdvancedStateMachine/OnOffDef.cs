using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffDef : MonoBehaviour
{
public Transform PlayerTarget;
    public float speed;
  

    public bool stopChase=false;
    Vector3 CurrentPosition;
    bool Flipped=false;
    public Animator anim;
  public bool isChase=false;
  public bool ReturnPosition=false;
  
   public float distance;
    public bool isDef=false;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance=Vector2.Distance(PlayerTarget.position,transform.position);
        if(isChase==false && isDef==false){
           
            if(distance < 5f){


                isChase=true;
              anim.SetBool("isFollowing",true);
            }  
        }

        if(distance >8f && isChase==true){
               
            isChase=false;
              Invoke("StopChase",1.5f);
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


        if(isDef==true){
            
        }
    }

    void StopChase(){
anim.SetBool("isFollowing",false);
isChase=false;
    }

     void Flip(){
        Flipped=!Flipped;

        transform.Rotate(0f,180f,0f);
    }
}
