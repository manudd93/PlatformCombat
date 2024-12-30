using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAdvanced : MonoBehaviour
{
    public int attackDamage;
    public Vector3 attackOffset;
    public float RangeAttack=1;
    public LayerMask attackMask;
    public Animator anim;
   public Transform target;
   public Transform AttackPoint;
   public Transform ShootPosition;
  public Rigidbody2D rb;
   public float distance;
    public float firerate=1.1f;
     float nextfire=0.0f;
   public  bool isAttack=false;
   public GameObject Bullet;
    EnemyStateController enemyController;
  

    // Start is called before the first frame update
    void Start()
    {
     
        rb=GetComponent<Rigidbody2D>();
        enemyController = GetComponent<EnemyStateController>();
    }

    // Update is called once per frame
    void Update()
    {
       

 distance=Vector2.Distance(target.position,transform.position);
            if(distance < 3f){
               
             anim.SetTrigger("Attack");
            }
             
        }
       
        
        
    

    public void Attack(){
      //  if (enemyController.isHurt) { return; }
        Vector3 pos =transform.position;
pos +=transform.right * attackOffset.x;
pos+=transform.up*attackOffset.y;
Collider2D colInfo=Physics2D.OverlapCircle(AttackPoint.position,RangeAttack,attackMask);
        if (colInfo != null)
        {
            if (colInfo.gameObject.tag == "Player")
            {
                colInfo.GetComponent<PlayerHealtSystem>().TakeDamage(attackDamage);
                colInfo.GetComponent<PlayerMovevement>().KnockBackCount = colInfo.GetComponent<PlayerMovevement>().KnockBackLenght;

                if (colInfo.transform.position.x < transform.position.x)
                {
                    colInfo.GetComponent<PlayerMovevement>().KnockbackRight = true;
                }
                else
                {
                    colInfo.GetComponent<PlayerMovevement>().KnockbackRight = false;
                }

            }
        }
           
}
 
    
public void HeavyAttack(){
        if (enemyController.isHurt) { return; }
        Collider2D colInfo=Physics2D.OverlapCircle(AttackPoint.position,RangeAttack+3f,attackMask);
if(colInfo!=null){
            if (colInfo.gameObject.tag == "Player")
            {
                colInfo.GetComponent<PlayerHealtSystem>().TakeDamage(attackDamage + 4);
                colInfo.GetComponent<PlayerMovevement>().KnockBackCount = colInfo.GetComponent<PlayerMovevement>().KnockBackLenght;

                if (colInfo.transform.position.x < transform.position.x)
                {
                    colInfo.GetComponent<PlayerMovevement>().KnockbackRight = true;
                }
                else
                {
                    colInfo.GetComponent<PlayerMovevement>().KnockbackRight = false;
                }

            }
        }
    

}

public void Shoot(){
        if (enemyController.isHurt) { return; }
        if (target.position.x <  transform.position.x){
     Bullet.gameObject.gameObject.GetComponent<BulletDir>().Flipped=false;

    }else{
Bullet.gameObject.gameObject.GetComponent<BulletDir>().Flipped=true;
    }
    Debug.Log("sparo");
     RaycastHit2D Shoot=Physics2D.Raycast(ShootPosition.position,target.position-transform.position,10f);
     if(Shoot.collider !=null){
            if(Shoot.collider.tag=="Player"){
                
                 Shoot.collider.GetComponent<PlayerHealtSystem>().TakeDamage(5);
                  Debug.DrawLine(transform.position,Shoot.point,Color.green);
            }

    }
Instantiate(Bullet,ShootPosition.transform.position,Bullet.transform.rotation);

}
void OnDrawGizmosSelected(){
        
          Gizmos.DrawWireSphere(AttackPoint.transform.position,RangeAttack);
       
    }
    
}
