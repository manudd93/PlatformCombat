using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunDef : StateMachineBehaviour
{
   Transform PlayerTarget;
    Rigidbody2D rb;
    public float speed=2.5f;
    public float distance;
  [SerializeField]
    OnOffDef enemyOn;
    bool CanMove=true;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         PlayerTarget=GameObject.FindGameObjectWithTag("Player").transform;
       rb=animator.GetComponent<Rigidbody2D>();
 enemyOn=GameObject.FindObjectOfType<OnOffDef>();

     }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
          rb.position=Vector2.MoveTowards(rb.position,PlayerTarget.position,speed *Time.deltaTime);
        
    

    
        distance=Vector2.Distance(PlayerTarget.position,rb.position);
         if(distance < 3f){
                 int Range=Random.Range(0,2);
                if(Range==1){
                    Debug.Log(Range);
                 animator.SetTrigger("Attack");
  
                }
                if(Range==0){
                    animator.SetTrigger("AttackHeavy"); 
                   Debug.Log(Range);
                }
                 
                
           
            }
 if(distance <=3f && Input.GetMouseButtonDown(1) && enemyOn.isChase==true){

               int Range2=Random.Range(0,10);
               if(Range2>=2){
                  
                  
                   
                   CanMove=false;
                   enemyOn.isDef=true;
                    animator.SetBool("isDef",true);
                    animator.SetBool("isFollowing",false);
               }
            
           }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("AttackHeavy");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
