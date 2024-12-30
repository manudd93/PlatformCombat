using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float firerate=1.1f;
     float nextfire=0.0f;
    public Animator anim;
    public Transform AttackPoint;
    public float attackRange=0.5f;
    public LayerMask EnemyLayer;
    public float ColdDownCombo=0.9f;
   public float LastClickedTime=0f;
    public int NumberClick=0;
      int Damage=10;
     public Rigidbody2D RB;
     PlayerMovevement playerMove;
    
    // Start is called before the first frame update
    void Start()
    {
        RB=GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerMove=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovevement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    if(Time.time - LastClickedTime>ColdDownCombo){
        NumberClick=0;
    }
        if (Input.GetMouseButtonDown(1) && Time.time > nextfire && NumberClick == 0){
LastClickedTime=Time.time;
            anim.SetTrigger("AttackMelee");
            NumberClick++;
            Debug.Log("attacco1");
           AddForce(75f);
            
        Collider2D[] HitEnemy= Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,EnemyLayer);

            foreach(Collider2D enemy in HitEnemy){
                Debug.Log("Lo Preso:"+enemy.name);
               if(enemy.GetComponent<EnemyBaseHealt>()==null){
                  
                }else{
                    enemy.GetComponent<EnemyBaseHealt>().TakeDamage(Damage);
                }
                
            }

            nextfire=Time.time+firerate;


        }
        if(Input.GetMouseButtonDown(1) && Time.time>nextfire && NumberClick==1){
LastClickedTime=Time.time;
            anim.SetTrigger("AttackMelee2");
            NumberClick++;
            Debug.Log("attacco2");
            Damage+=4;
            AddForce(75f);
        Collider2D[] HitEnemy= Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,EnemyLayer);

            foreach(Collider2D enemy in HitEnemy){
                Debug.Log("Lo Preso:"+enemy.name);
                if(enemy.GetComponent<EnemyBaseHealt>()==null){
                   
                }else{
                    enemy.GetComponent<EnemyBaseHealt>().TakeDamage(Damage);
                }
            }

            nextfire=Time.time+firerate;


        }
        if(Input.GetMouseButtonDown(1) && Time.time>nextfire && NumberClick==2){
LastClickedTime=Time.time;
            anim.SetTrigger("AttackMelee3");
            NumberClick=0;
            Debug.Log("attacco3");
            Damage+=7;
            AddForce(75f);
        Collider2D[] HitEnemy= Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,EnemyLayer);

            foreach(Collider2D enemy in HitEnemy){
                Debug.Log("Lo Preso:"+enemy.name);
                if(enemy.GetComponent<EnemyBaseHealt>()==null){
                   
                }else{
                    enemy.GetComponent<EnemyBaseHealt>().TakeDamage(Damage);
                }
                
            }

            nextfire=Time.time+firerate;

Damage=10;
        }
    }

    void OnDrawGizmosSelected(){
        if(AttackPoint==null){
            return;
           
        }
         Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
public void AddForce(float Force){
    if(playerMove.Flipped==true){
 RB.AddForce(Vector2.left*Force);
    }else{
RB.AddForce(Vector2.right*Force);
    }
    
}
    
}
