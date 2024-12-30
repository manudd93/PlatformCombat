using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackType : MonoBehaviour
{
    EnemyMovement enemyMovement;
    PlayerHealtSystem playerHealtSystem;
    EnemyStateController enemyStateController;
    public TypeAttack tipoAttacco;
    Animator anim;
    public int Damage;
    public bool RangeDamage=false;
   
    public float range = 1;
    public LayerMask mask;
    public float firerate = 1.1f;
    float nextfire = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
        enemyStateController = GetComponent<EnemyStateController>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyStateController.ChangeState(StateEnemy.ChasePlayer);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && enemyMovement.Hurt==false)
        {
            Debug.Log("collide il player");

            if (Time.time > nextfire)
            {
                anim.SetTrigger("Attack");
                anim.SetBool("Movement", false);

                enemyStateController.ChangeState(StateEnemy.AttackPlayer);
                Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(transform.position, range, mask);

                foreach (Collider2D enemy in HitEnemy)
                {
                    Debug.Log("Lo Preso:" + enemy.name);
                    if (enemy.GetComponent<PlayerHealtSystem>() == null)
                    {

                    }
                    else
                    {
                        enemy.GetComponent<PlayerHealtSystem>().TakeDamage(Damage);


                        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();


                    }

                }
                nextfire = Time.time + firerate;
            }
        }
    }
  
}
public enum TypeAttack
{
    OnlyTouch,
    TouchAndHitType,
    OneHitType,
    ComboAttackMode,
}

