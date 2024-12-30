using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float Waiting;
    public bool movingright=true;
    public Transform GroundDetection;
    public Animator anim;
    public bool Hurt=false;
    public bool Stop=false;
  
   public LayerMask groundLayer;
    public Collider2D WallCheck;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hurt==false && Stop==false){
            anim.SetBool("isMoving",true);
             transform.Translate(Vector2.left*speed*Time.deltaTime);
             
        }

        Debug.DrawRay(GroundDetection.position, Vector2.down, Color.red);

        
        RaycastHit2D groundInfo=Physics2D.Raycast(GroundDetection.position,Vector2.down,1f);
        
         
            
        

        if (groundInfo.collider==false || WallCheck.IsTouchingLayers(groundLayer))
        {
        if(Stop==false){
            anim.SetBool("isMoving",false);
  Invoke("Restart",Waiting);
        }
         Stop=true;
        

        }
    
    }
    public void Hurting()
    {
        Hurt = true;
        Invoke("Removing", 0.5f);

    }
    public void Removing()
    {
        Hurt = false;
    }
    void Restart()
    {


        if (movingright == true)
        {
            transform.Rotate(0, -180, 0);
            movingright = false;

            Stop = false;

        }
        else if (movingright == false)
        {
            transform.Rotate(0, 180, 0);
            movingright = true;


            Stop = false;
        }




    }
}
