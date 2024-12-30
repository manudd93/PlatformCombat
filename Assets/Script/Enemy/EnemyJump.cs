using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponentInParent<Rigidbody2D>(); 
       anim=GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
       
    Debug.Log(col.gameObject.name);
    if(col.gameObject.name=="OstacoloGrande"){
anim.SetTrigger("Jump");
      rb.AddForce(Vector2.up*700f);
    }
    }
}
