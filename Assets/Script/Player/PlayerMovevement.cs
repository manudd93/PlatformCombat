 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovevement : MonoBehaviour
{
    public LayerMask whatisGround;
    public Transform feet;
  public  bool Flipped=false;
 
 public  bool isJump=false;
 public float KnockBack;
 public float KnockBackLenght;
 public bool KnockbackRight;
 public float KnockBackCount;
    public AnimationClip MoveClip;
    public AnimationClip IdleClip;
    public AnimationClip JumpClip;

    public Animator anim;
    [SerializeField]
    GameObject Player;
    [SerializeField]
      Rigidbody2D  RB;
      [SerializeField]
      CapsuleCollider2D ColliderCapsule;
      [SerializeField]
      float PowerJump;
   public float HorizontalMove;
      
    public float MoveSpeed=2f;
    public bool IsMoving;
    MeleeAttackSystem meleeAttack;
    PlayerStateController playerStateController;
    FootStepSound footStepSound;
    public float jumpCounter;
    public float Jumptimer;
    
void Awake(){
    
    
}

    void Start()
    {
     RB.GetComponent<Rigidbody2D>();
     ColliderCapsule=transform.GetComponent<CapsuleCollider2D>();
        meleeAttack = GameObject.FindObjectOfType<MeleeAttackSystem>();
        playerStateController = GetComponent<PlayerStateController>();
        footStepSound=GetComponent<FootStepSound>();
    }

 
    void FixedUpdate()
    {

        if (StatePlayer.Attacking==PlayerStateController.GetState() || StatePlayer.Hurting == PlayerStateController.GetState()) {
           
            return;
            }

        if(KnockBackCount<=0){
        if(Input.GetKey(KeyCode.D) && playerStateController.isHurt == false)
            {
               // Player.transform.Translate(new Vector3(1f*MoveSpeed*Time.deltaTime,0f,0f));
          HorizontalMove=Input.GetAxisRaw("Horizontal");
                RB.velocity = new Vector2(HorizontalMove * MoveSpeed, RB.velocity.y);
       
           
            if(Flipped==true){
                Flip();
            }

            }
            
         if(Input.GetKey(KeyCode.A) && playerStateController.isHurt == false)
            {
               
                //Player.transform.Translate(new Vector3(1f*MoveSpeed*Time.deltaTime,0f,0f));
            HorizontalMove=Input.GetAxisRaw("Horizontal");
           
                RB.velocity = new Vector2(HorizontalMove * MoveSpeed, RB.velocity.y);



                if (Flipped==false){
                Flip();
            }
        }
           
        }
        else{
            if(KnockbackRight){
              RB.velocity=new Vector2(-KnockBack,KnockBack-2);  
            }
            if(!KnockbackRight){
                 RB.velocity=new Vector2(KnockBack,KnockBack);
            }
            KnockBackCount -=Time.deltaTime;
            
        }
        if(Input.GetAxisRaw("Horizontal")==0){
  
          
           HorizontalMove=0f;
        }
        if (isGrounded()==true)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
             
                PlayerStateController.ChangeState(StatePlayer.Walking);
                //RB.drag=15;
             
            }
            else
            {
                PlayerStateController.ChangeState(StatePlayer.Idle);
               // RB.drag=0;
             
            }
        }
       
if(isGrounded()==true){
 

isJump=false;
      }else{
          isJump=true;
        }
        
        
    }

    void Update(){
        if(Input.GetButtonDown("Jump")&& isGrounded() && playerStateController.isHurt==false  ){
            //RB.velocity = Vector2.zero;
            RB.velocity= Vector2.up*PowerJump;
            //// RB.drag=25;
          

        }



    }
  

    public bool isGrounded(){

        bool state;
        float extraHeight = 0.5f;
        state = Physics2D.OverlapCircle(feet.position, extraHeight, whatisGround);
        //     float extraHeight=0.5f;
        //     RB.drag=0;
        //RaycastHit2D raycastHit= Physics2D.Raycast(ColliderCapsule.bounds.center,Vector2.down,ColliderCapsule.bounds.extents.y+extraHeight,mask);
        // Color rayColor;
        // if(raycastHit.collider !=null){

        //     rayColor=Color.green;

        // }else{

        //     rayColor=Color.red;


        // } 


        //     Debug.DrawRay(ColliderCapsule.bounds.center,Vector2.down*(ColliderCapsule.bounds.extents.y+extraHeight),rayColor);         

        //     return raycastHit.collider !=null;

        return state;

    }
    void Flip(){
        Flipped=!Flipped;
Player.transform.Rotate(0f,180f,0f);
    }

     public void KnockBackPlayer(float Force)
    {
        IsMoving=false;
        RB.velocity=Vector2.zero;
            StopAllCoroutines();
        if (Flipped == true)
        {
             Vector2 direction=(Vector2.left).normalized;
            RB.AddForce(direction*Force,ForceMode2D.Impulse);
        }
        else
        {
            Vector2 direction=(Vector2.right).normalized;
            RB.AddForce(direction*Force,ForceMode2D.Impulse);
        }
         StartCoroutine(Reset());
    }

    private IEnumerator Reset(){
    yield return new WaitForSeconds(0.7f);
    RB.velocity=Vector3.zero;
    
   
   }
    
    
    public void CallAnimationPlay()
    {
        meleeAttack.TriggerAttack();
    }
    public void CallAnimationEnd()
    {
        meleeAttack.StopAttack();
    }
    
}
