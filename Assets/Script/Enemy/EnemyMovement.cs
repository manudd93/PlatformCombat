using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    public float Waiting;
    public float Direction;
    public Transform GroundDetection;
    public Animator anim;
    public bool Hurt = false;
    public bool Stop = false;
    public bool TargetFountain = false;
    public LayerMask groundLayer;
    Rigidbody2D rb;
    public Collider2D WallCheck;
    public MovementType movementType;
    public Comportamento comportamento;
    
    public Transform PlayerTarget;
    public Transform FountainTarget;
    public bool stopChase = false;
    Vector3 CurrentPosition;
    public bool Flipped = true;
    public bool isChase = false;
    public bool ReturnPosition = false;
    EnemyStateController enemyStateController;
  [SerializeField]  private float distance;
    
    public float DistanceTrigger;
    public float DistanceRelase;
    public float TimerRelaseTrigger;
    public bool CanGoDefenseMode;
    RaycastHit2D groundInfo;
    RaycastHit2D groundInfo2;
    // Start is called before the first frame update

    // Update is called once per frame
   EnemyBaseHealt enemyBaseHealt;
   private void Start() {
    enemyBaseHealt=GetComponent<EnemyBaseHealt>();
        enemyStateController = GetComponent<EnemyStateController>();
        rb = GetComponent<Rigidbody2D>();
        enemyStateController.ChangeState(StateEnemy.ChasePlayer);
   }
   
    void Update()
    {
       
        if (enemyBaseHealt.Healt <=0){
            return;
        }
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        FountainTarget = GameObject.FindGameObjectWithTag("Fontana").transform;

        groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 1f);
        groundInfo2 = Physics2D.Raycast(GroundDetection.position, Vector2.left, 0.1f);
         Direction = Mathf.Sign(PlayerTarget.transform.position.x - transform.position.x);
        if (groundInfo.collider==false)
        {
            Debug.DrawRay(GroundDetection.position, Vector2.down, Color.red);
        }
        else
        {
            Debug.DrawRay(GroundDetection.position, Vector2.down, Color.blue);
        }
        distance = Vector2.Distance(PlayerTarget.position, transform.position);
        if (movementType == MovementType.Patrolling && Stop==false && Hurt==false)
        {
            
           PatrolGround();
        }

        if(movementType == MovementType.WaitPlayer && Stop == false && Hurt == false)
        {
            ChasePlayer();
            LookPlayer();
            
        }

        if (movementType == MovementType.PatrollingAndChasePlayer && Stop == false && Hurt == false)
        {
            if (distance < DistanceTrigger)
            {
                ChasePlayer();
                LookPlayer();
            }
            else
            {
                if (distance > DistanceRelase && isChase == true)
                {

                    isChase = false;
                    Invoke("StopChase", TimerRelaseTrigger);
                }
                PatrolGround();
               
            }
        }

        if(movementType==MovementType.AttackPlayer && Stop==false && Hurt == false && enemyStateController.stateEnemy != StateEnemy.AttackPlayer && enemyStateController.stateEnemy==StateEnemy.ChasePlayer)
        {
            ChasePlayer();
            LookPlayer();
            if (distance< DistanceTrigger)
            {
                //Debug.Log("sei vicino");
             
            }
            else
            {
                //if (distance > DistanceRelase && isChase == true)
                //{

                //    isChase = false;
                //    Invoke("StopChase", TimerRelaseTrigger);
                //}

            }

        }

       
    }

        void PatrolGround()
    {
        anim.SetBool("isMoving", true);
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if(groundInfo2 ==false)
        {
            return;
        }
        /*
        if (WallCheck.IsTouchingLayers(groundLayer))
        {
            Debug.Log("tocco");
        }
        groundInfo.collider == false || groundInfo2.collider==true
        */
        if (!groundInfo2.collider.IsTouchingLayers(groundLayer) || groundInfo.collider == false )
            //WallCheck.IsTouchingLayers(groundLayer)
           
        // groundInfo.collider == false ||
        {
            
            if (Stop == false)
            {
               
                anim.SetBool("isMoving", false);
              
                Invoke("Restart", Waiting);
                Debug.Log("restart");
                Stop = true;
            }
            
              

        }
       
    }
    void ChasePlayer()
    {



        if (!TargetFountain)
        {

           anim.SetBool("isMoving", true);
            enemyStateController.ChangeState(StateEnemy.ChasePlayer);

            rb.velocity = new Vector2(Direction * Speed, rb.velocity.y);
            Debug.Log("Inseguire");

           // transform.position = Vector2.MoveTowards(transform.position, PlayerTarget.position, Speed*Time.deltaTime);
        }
        else
        {
         //   transform.position = Vector2.MoveTowards(transform.position, FountainTarget.position, Speed * Time.deltaTime);
        }
            

        
        //if (distance > DistanceRelase && isChase == true)
        //{
        //    isChase = false;
        //    Invoke("StopChase", TimerRelaseTrigger);
        //}
    }
    void StopChase()
    {
        anim.SetBool("isMoving", false);
        isChase = false;
    }
    void AttackFountain()
    {
        TargetFountain = true;
    }
    public void Hurting()
    {
        Hurt = true;
        Invoke("Removing", 0.5f);

    }
    public void Removing()
    {
        Hurt = false;
    }
    void Restart()
    {
       

        if (Flipped == true)
        {
            
            transform.Rotate(0, -180, 0);
            Flipped = false;

            Stop = false;

        }
        else if (Flipped == false )
        {
            transform.Rotate(0, 180, 0);
            Flipped = true;


            Stop = false;
        }




    }

    public void LookPlayer()
    {
        if (!TargetFountain)
        {
            if (PlayerTarget.transform.position.x > transform.position.x)
            {

                if (Flipped == true)
                {
                    Restart();
                }
            }
            else
            {

                if (Flipped == false)
                {
                    Restart();
                }
            }

        }
        else
        {
          if(FountainTarget.transform.position.x > transform.position.x)
            {
                if (Flipped == true)
                {
                    Restart();
                }
            }
            else
            {
                if (Flipped == false)
                {
                    Restart();
                }
            }
        }
    }
}
    public enum MovementType
    {
        Patrolling,
        PatrollingAndChasePlayer,
        AttackPlayer,
        WaitPlayer,
        FlyPatrolling,
        FlyOnThePlayer,
    }


public enum Comportamento
{
    Nothing,
OnlyMovingGround,
MovingAndAttackGround,

}

