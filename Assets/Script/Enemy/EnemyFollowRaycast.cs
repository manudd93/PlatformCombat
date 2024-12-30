using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowRaycast : MonoBehaviour
{
    public Transform EyeRay;
    public float EyeLong;
    StartChase ChaseScript;
    public Animator anim;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        ChaseScript=GameObject.FindObjectOfType<StartChase>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       RaycastHit2D Eye=Physics2D.Raycast(transform.position,Vector3.left,EyeLong);
        if(Eye.collider!=null){
            if(Eye.collider.tag=="Player"){
                 ChaseScript.isChasing=true;
                  Debug.Log(" ti vedo");
                   Debug.DrawLine(transform.position,Eye.point,Color.red);
            }
            

    }else
    {
Debug.DrawRay(transform.position,Vector2.left*EyeLong,Color.blue);
        Debug.Log("non ti vedo");
    }
 
     

    
    
    }
    
}
