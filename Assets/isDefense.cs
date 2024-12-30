using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDefense : StateMachineBehaviour
{
    OnOffDef enemyOn;
      public float timer=2f;
bool stopTime;

[SerializeField]
EnemyBaseHealt enemyheal;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
 enemyOn=GameObject.FindObjectOfType<OnOffDef>();
enemyheal=animator.gameObject.GetComponent<EnemyBaseHealt>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
if(!stopTime){
    enemyheal.OnDefenseMode=true;
             timer-=Time.deltaTime;
}else{
    enemyOn.isDef=false;
    enemyOn.isChase=false;
   
    stopTime=false;
    timer=2f;
    animator.SetBool("isDef",false);
}
       
        if(timer<=0){
            stopTime=true;
        }
        if(!stopTime && Input.GetMouseButtonDown(1)){
            timer=2f;
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

 enemyheal.OnDefenseMode=false;

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
