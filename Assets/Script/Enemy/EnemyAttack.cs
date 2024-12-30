using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
     public float firerate=1.1f;
     float nextfire=0.0f;
    
    public Transform AttackPoint;
    public float attackRange=0.5f;
    public Animator anim;
    public bool isAttack;
    int Damage=10;
     public LayerMask EnemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttack &&  Time.time>nextfire ){

            anim.SetTrigger("Attack");
            
          
        Collider2D[] HitPlayer= Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,EnemyLayer);

            foreach(Collider2D player in HitPlayer){
                Debug.Log("Ti Ho Preso Peppe:"+player.name);
                player.GetComponent<PlayerHealtSystem>().TakeDamage(Damage);
                player.GetComponent<PlayerMovevement>().KnockBackCount =player.GetComponent<PlayerMovevement>().KnockBackLenght;
             
            if(player.transform.position.x< transform.position.x){
                player.GetComponent<PlayerMovevement>().KnockbackRight=true;
            }else{
                player.GetComponent<PlayerMovevement>().KnockbackRight=false;
            }
           
            }

            nextfire=Time.time+firerate;


        }
    }
    void OnTriggerEnter2D(Collider2D col){
//if(col.gameObject.tag=="Player"){
 //   isAttack=true;
//}

anim.SetTrigger("Attack");
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
    isAttack=false;
}
    }

     void OnDrawGizmosSelected(){
        if(AttackPoint==null){
            return;
           
        }
         Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
}
