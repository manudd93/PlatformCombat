using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAndDef : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Attack(){
       

           
}
 
    
public void HeavyAttack(){

}

}
