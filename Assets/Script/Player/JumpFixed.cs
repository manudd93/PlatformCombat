using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFixed : MonoBehaviour
{
     public  float fallmultiplier;
      public float lowJump;
      [SerializeField]
      Rigidbody2D  RB;
    // Start is called before the first frame update
    void Start()
    {
         RB.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RB.velocity.y<0){
            RB.velocity += Vector2.up * Physics2D.gravity.y *(fallmultiplier-1)*Time.deltaTime;
        }else if(RB.velocity.y>0 && !Input.GetButton("Jump")){
            
            RB.velocity += Vector2.up * Physics2D.gravity.y *(lowJump-1)*Time.deltaTime;
            
        }
    }
}
