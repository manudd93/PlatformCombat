using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackSystem : MonoBehaviour
{
    //ATTACK SYSTEM BY ULTRALORD V1.1
    //public List<AttackPropieties> TypeAttack;
    //public AnimationClip ClipAnim;

    public List<AttackPropieties> NumberAttack = new List<AttackPropieties>();
    public AudioSource audioSource;
    public List<AnimationClip> AttackClip = new List<AnimationClip>();
    public AnimationClip IdleClip;
    public AnimationClip WalkClip;
    public AnimationClip JumpClip;
    public float firerate = 1.1f;
    float nextfire = 0.0f;
    public Animator anim;
    public Transform AttackPoint;
    Rigidbody2D RB;
    PlayerMovevement playerMove;
    public float ColdDownCombo = 0.9f;
    public float LastClickedTime = 0f;
    [SerializeField] int NumberClick = 0;
    public bool isAttacking = false;
    public Camera cam;
     PlayerStateController playerStateController;
    Vector3 MousePos;
    int DamageGrowing;
    int IncreasePlusDamage;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerMove = GetComponentInParent<PlayerMovevement>();
        RB = GetComponentInParent<Rigidbody2D>();
        playerStateController = GetComponentInParent<PlayerStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( PlayerStateController.GetState() != StatePlayer.Attacking ||  PlayerStateController.GetState() != StatePlayer.Stunning)
        {
            if (PlayerStateController.GetState() != StatePlayer.Attacking)
            {


                if (playerMove.isJump)
                {
                    CustomAnimator.PlayAnimationState(JumpClip.name);
                }
                if (playerMove.isGrounded() == true)
                {


                    if (PlayerStateController.GetState() == StatePlayer.Walking)
                    {
                        CustomAnimator.PlayAnimationState(WalkClip.name);
                    }
                    else if(PlayerStateController.GetState() == StatePlayer.Idle)
                    {
                        CustomAnimator.PlayAnimationState(IdleClip.name);
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && Time.time > nextfire && NumberClick < NumberAttack.Count && playerStateController.isHurt == false && PlayerStateController.GetState() != StatePlayer.Attacking)
        {
          
            PlayerStateController.ChangeState(StatePlayer.Attacking);
            LastClickedTime = Time.time;
            switch (NumberAttack[NumberClick].TypeAttack)
            {



                case AttackPropieties.InformationAttack.Ranged:
                    Debug.Log("attacco a distanza");

                    if (NumberAttack[NumberClick].Ranged == AttackPropieties.RangedType.Unidirectional)
                    {
                        RangedAttackUnidirectioal(NumberClick);
                    }
           

                    else
                    {
                        RangedAttackCursor(NumberClick);
                    }
            
                    break;
                case AttackPropieties.InformationAttack.Melee:
//                    Debug.Log("attacco a ravvicinato");
                    if (NumberAttack[NumberClick].TriggerAttack)
                    {
                        CustomAnimator.PlayAnimationState(AttackClip[NumberClick].name);
                    }
                    else
                    {
                        IstantAttack(NumberClick);
                    }
                    break;

                case AttackPropieties.InformationAttack.AOE:
                    Debug.Log("attacco aoe ");
                    break;
            }
            // Invoke("StopAttack", NumberAttack[NumberClick].AttackClipAnim.length);
            //Attack(NumberClick);
            nextfire = Time.time + firerate;
            NumberClick++;

        }


        if (Time.time - LastClickedTime > ColdDownCombo)
        {
            NumberClick = 0;

        }




        if (NumberClick > NumberAttack.Count)
        {
            NumberClick = NumberAttack.Count;
        }
    }

    public void Attack(int index)
    {
       // Debug.Log(NumberAttack[index].Information);
    }


    public void IncreaseDamage(int Amount)
    {
        IncreasePlusDamage += Amount;
    }
    public void RangedAttackUnidirectioal(int index)
    {
        Debug.Log("RangedUnidirectional");
        
        if (NumberAttack[NumberClick].CastTime<= 0f){
            GameObject Shooting = Instantiate(NumberAttack[index].PrefabShooting, AttackPoint.position, Quaternion.identity);
            Rigidbody2D rbBull = Shooting.GetComponent<Rigidbody2D>();
            BulletSystem BS = Shooting.GetComponent<BulletSystem>();
            BS.SetBullet(NumberAttack[index].Damage, 5, 5);
            rbBull.AddForce(AttackPoint.right * 10f, ForceMode2D.Impulse);
            isAttacking = false;
        }
        else
        {
            StartCoroutine(CastTimeing(index));
        }
      
        
        //  CustomAnimator.PlayAnimationState(NumberAttack[index].AttackClipAnim.name);

    }

    IEnumerator CastTimeing(int index)
    {
        Debug.Log("Casting");
        yield return new WaitForSeconds(NumberAttack[index].CastTime);
        GameObject Shooting = Instantiate(NumberAttack[index].PrefabShooting, AttackPoint.position, Quaternion.identity);
        isAttacking = false;
    }
    public void RangedAttackCursor(int index)
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 LookDir = AttackPoint.position-MousePos;
        float angle = Mathf.Atan2(-LookDir.x, LookDir.y) * Mathf.Rad2Deg;
        AttackPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle-90);


        GameObject BulletInst = Instantiate(NumberAttack[index].PrefabShooting, AttackPoint.transform.position, AttackPoint.rotation);
        Rigidbody2D rbBull = BulletInst.GetComponent<Rigidbody2D>();
        rbBull.AddForce(AttackPoint.right * 10f, ForceMode2D.Impulse);
        if (NumberAttack[NumberClick].CastTime <= 0f)
        {
            //GameObject Shooting = Instantiate(NumberAttack[index].PrefabShooting, AttackPoint.position, Quaternion.identity);
            isAttacking = false;
        }
        else
        {
            
        }
    }
    public void IstantAttack(int index)
    {
        CustomAnimator.PlayAnimationState(NumberAttack[index].AttackClipAnim.name);
        AddForce(NumberAttack[NumberClick - 1].SpintaAttacco);
        
        Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, NumberAttack[index].attackRange, NumberAttack[index].AttackMask);

        foreach (Collider2D enemy in HitEnemy)
        {
            Debug.Log("Lo Preso:" + enemy.name);
            if (enemy.GetComponent<EnemyBaseHealt>() == null)
            {

            }
            else
            {
                enemy.GetComponent<EnemyBaseHealt>().TakeDamage(NumberAttack[index].Damage);
                enemy.GetComponent<EnemyStateController>().OnHurt();
                // enemy.GetComponent<EnemyStateController>().KnockbackMe(NumberAttack[index].KnockPosition, 10f);
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
               
               
            }

        }
       
    }
    public void TriggerAttack()
    {

        
       
        AddForce(NumberAttack[NumberClick - 1].SpintaAttacco);

        Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, NumberAttack[NumberClick-1].attackRange, NumberAttack[NumberClick-1].AttackMask);

        foreach (Collider2D enemy in HitEnemy)
        {
            
            if (enemy.GetComponent<EnemyBaseHealt>() != null)
            {
                audioSource.volume = Mathf.Clamp01(0.2f);
                audioSource.PlayOneShot(NumberAttack[NumberClick - 1].SFXAttackHit);
                enemy.GetComponent<EnemyBaseHealt>().TakeDamage(NumberAttack[NumberClick - 1].Damage+DamageGrowing+IncreasePlusDamage);
                 
                  if(NumberAttack[NumberClick-1].Information=="KnockUp"){
 enemy.GetComponent<KnockBackFeedBack>().PlayKnockUp(this.gameObject,playerMove.Flipped,NumberAttack[NumberClick - 1].KnockPower,NumberAttack[NumberClick - 1].KnockDelay);
                  }else{
 enemy.GetComponent<KnockBackFeedBack>().PlayFeedBack(this.gameObject,NumberAttack[NumberClick - 1].KnockPower,NumberAttack[NumberClick - 1].KnockDelay);
                  }
                  
                 CinemachineShake.Instance.ShakeCamera(3f,0.2f);
                    if(NumberAttack[NumberClick - 1].TypeDebuff != Debuff.Nothing && CalculateChance(NumberAttack[NumberClick - 1].PercentageDebuff))
                    {
                    enemy.GetComponent<EnemyStateController>().ApplyStateProblem(NumberAttack[NumberClick - 1].TypeDebuff, NumberAttack[NumberClick - 1].TimeDebuff, NumberAttack[NumberClick - 1].ValueOfDebuff);

                    }
 try
                {
                   
                }
                catch (System.Exception)
                {

                   
                }
            }
            else
            {
               
               
               return;
               
            }

        }
       
    }
    public void LevelUp(int newDamage)
    {
        DamageGrowing = newDamage;
    }

    public void StopAttack()
    {
        Debug.Log("cambio stato0");
        PlayerStateController.ChangeState(StatePlayer.Idle);
    }

    bool CalculateChance(int percentage)
    {
        int Value = Random.Range(0, 100);
        if (Value <= percentage)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void AddForce(float Force)
    {
            StopAllCoroutines();
        if (playerMove.Flipped == true)
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


  
}

    [System.Serializable]
public class AttackPropieties
{
    public LayerMask AttackMask;

    public float attackRange = 0.5f;
    public string Information = "";
    public int Damage;
    public float SpintaAttacco = 0f;
    public float KnockPower = 0f;
  public float KnockDelay=1;
    public AnimationClip AttackClipAnim;
    public InformationAttack TypeAttack;
    public RangedType Ranged;
    public Debuff TypeDebuff;
    public int TimeDebuff;
    public int PercentageDebuff;
    public int ValueOfDebuff;
    public bool TriggerAttack = false;
    public bool Charged = false;
    public GameObject PrefabShooting;
    public float CastTime = 0f;
    public AudioClip SFXAttack;
    public AudioClip SFXAttackHit;


   public enum InformationAttack
    {
        Melee,
        Ranged,
        AOE



    }
   public enum RangedType
    {
        Cursor,
        Unidirectional,
    }

 


}
public enum Debuff
{
    Nothing,
    Stordimento,
    Rallentamento,
    RiduzioneDanni,
    RiduzioneDifesa,
    Sanguinamento,
    Avvelenamento,
    Scotttatura
}

