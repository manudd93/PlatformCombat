using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchDamage : MonoBehaviour
{
   public PlayerHealtSystem playerhealt;
   PlayerMovevement playermov;
       public int DamageTouch;
    // Start is called before the first frame update
    void Start()
    {
        playerhealt=GameObject.FindObjectOfType<PlayerHealtSystem>();
       playermov=GameObject.FindObjectOfType<PlayerMovevement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
            playerhealt.TakeDamage(DamageTouch);
            playermov.KnockBackCount =playermov.KnockBackLenght;
            if(col.transform.position.x< transform.position.x){
                playermov.KnockbackRight=true;
            }else{
                playermov.KnockbackRight=false;
            }
           
        }else{
            return;
        }
    }
    
}
