using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachineBehaviour
{
    Rigidbody2D rb;
    EnemyMovement enemyMovement;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        enemyMovement = animator.GetComponent<EnemyMovement>();
    }
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyMovement.comportamento == Comportamento.OnlyMovingGround)
        {
            //  rb.position = Vector2.MoveTowards(rb.position, enemyMovement.PlayerTarget.position, enemyMovement.Speed * Time.deltaTime);
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(enemyMovement.PlayerTarget.position.x, rb.position.y), enemyMovement.Speed * Time.deltaTime);
        }
        if (enemyMovement.comportamento == Comportamento.MovingAndAttackGround)
        {
            //  rb.position = Vector2.MoveTowards(rb.position, enemyMovement.PlayerTarget.position, enemyMovement.Speed * Time.deltaTime);
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(enemyMovement.PlayerTarget.position.x, rb.position.y), enemyMovement.Speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
