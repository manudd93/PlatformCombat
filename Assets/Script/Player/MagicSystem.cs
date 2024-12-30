using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagicSystem : MonoBehaviour
{
    public LayerMask AttackMask;

    public float AOERange = 0.5f;
    public string Information = "";
    public float CastTime = 0f;
    public float ChargedTime = 0f;
    public float MaxChargedTime = 3f;
    public float firerate = 1.1f;
    float nextfire = 0.0f;
    public int Damage;
    public int MaxDamage;
    public int SpeedBullet;
    public int TimeDestroyBullet;
    public int IgnoringDefense = 0;
    public float KnockBack = 0f;
    public Vector2 KnockPosition;
    public AnimationClip AttackClipAnim;
    public Debuff TypeDebuff;
    public MagicType magicType;
    public DirectionType directionType;
    public int TimeDebuff;
    public int PercentageDebuff;
    public int ValueOfDebuff;
    public bool TriggerAttack = false;
    public bool Charged = false;
    public GameObject PrefabShooting;
    public GameObject TargetSelected;
    Action action;
    
    //MAGIC SYSTEM BY ULTRALORD V1.0 beta
    // Start is called before the first frame update
    public Animator anim;
    public Transform AttackPoint;
    Rigidbody2D RB;
    PlayerMovevement playerMove;
    public bool isAttacking = false;
    public Camera cam;
    PlayerStateController playerStateController;
    Vector3 MousePos;
    MeleeAttackSystem meleeAttackSystem;
    void Start()
    {
        cam = Camera.main;
        playerMove = GetComponentInParent<PlayerMovevement>();
        RB = GetComponentInParent<Rigidbody2D>();
        playerStateController = GetComponentInParent<PlayerStateController>();
        meleeAttackSystem = GameObject.FindObjectOfType<MeleeAttackSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Charged)
        {
            if (Input.GetMouseButton(0))
            {
                // meleeAttackSystem.isAttacking = true;
                PlayerStateController.ChangeState(StatePlayer.Attacking);
                Debug.Log("InizioCarica");
                ChargedTime += Time.deltaTime;
                if (ChargedTime >= MaxChargedTime)
                {
                    ChargedTime = MaxChargedTime;
                }
            }

            if (Input.GetMouseButtonUp(0) && Time.time > nextfire)

            {
                //meleeAttackSystem.isAttacking = false;
                PlayerStateController.ChangeState(StatePlayer.Idle);
                float newDamage = Damage +ChargedTime *7;
                int NewDamage = Mathf.RoundToInt(newDamage);
                Debug.Log(NewDamage);
                Debug.Log("RilascioCarica");
               
               // meleeAttackSystem.isAttacking = false;
                switch (magicType)
                {



                    case MagicType.Shoot:
                        Shoot(NewDamage);

                        break;
                    case MagicType.AOE:
                        AOE(NewDamage);
                        

                        
                        break;

                    case MagicType.Buff:
                        Debug.Log("cant be assing");
                        break;
                }
                nextfire = Time.time + firerate;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextfire)
            {

                //  meleeAttackSystem.isAttacking = true;
                PlayerStateController.ChangeState(StatePlayer.Attacking);
                switch (magicType)
                {



                    case MagicType.Shoot:
                        if (CastTime <= 0)
                        {
                            Shoot(Damage);
                        }
                        else
                        {
                            StartCoroutine(CastTimeing(Damage, Shoot));
                        }
                       

                        break;
                    case MagicType.AOE:
                        if (CastTime <= 0)
                        {
                          AOE(Damage);
                        }
                        else
                        {
                            StartCoroutine(CastTimeing(Damage, AOE));
                        }
                        
                        break;

                    case MagicType.Buff:

                        break;
                }
                nextfire = Time.time + firerate;
            }
        }
        
    }


    void Shoot(int Damage)
    {

        switch (directionType)
        {
            case DirectionType.Cursor:

                CursorShoot(Damage);
                break;


            case DirectionType.Unidirectional:

                UnidirectionalShoot(Damage);
                break;


            case DirectionType.Target:

               
                break;
        }

    }
    void CursorShoot(int Damage)
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 LookDir = AttackPoint.position - MousePos;
        float angle = Mathf.Atan2(-LookDir.x, LookDir.y) * Mathf.Rad2Deg;
        AttackPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);


        GameObject BulletInst = Instantiate(PrefabShooting, AttackPoint.transform.position, AttackPoint.rotation);
        Rigidbody2D rbBull = BulletInst.GetComponent<Rigidbody2D>();
        if (Charged == true)
        {
            if (ChargedTime <= 1)
            {
                ChargedTime = 1;
            }
            Vector2 scaleChange = new Vector2(rbBull.transform.localScale.x, rbBull.transform.localScale.y);
            rbBull.transform.localScale = scaleChange * ChargedTime;
            ChargedTime = 0f;
        }
        
        rbBull.AddForce(AttackPoint.right * 10f, ForceMode2D.Impulse);
        rbBull.GetComponent<BulletSystem>().SetBullet(Damage, this.SpeedBullet, this.TimeDestroyBullet);

        if (CastTime <= 0f)
        {

            PlayerStateController.ChangeState(StatePlayer.Idle);
        }
        

    }


    void UnidirectionalShoot(int Damage)
    {
        GameObject Shooting = Instantiate(PrefabShooting, AttackPoint.position, Quaternion.identity);
        Rigidbody2D rbBull = Shooting.GetComponent<Rigidbody2D>();
        BulletSystem BS = Shooting.GetComponent<BulletSystem>();
         if (Charged == true)
        {
            if (ChargedTime <= 1)
            {
                ChargedTime = 1;
            }
            Vector2 scaleChange = new Vector2(rbBull.transform.localScale.x, rbBull.transform.localScale.y);
            rbBull.transform.localScale = scaleChange * ChargedTime;
            ChargedTime = 0f;
        }
        BS.SetBullet(Damage, 5, 5);
        rbBull.AddForce(AttackPoint.right * 10f, ForceMode2D.Impulse);
        meleeAttackSystem.isAttacking = false;

    }
       

    void TargetShoot()
    {

    }
    void Buff()
    {


    }
    void AOE(int damage)
    {
        Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(transform.position, AOERange, AttackMask);

        foreach (Collider2D enemy in HitEnemy)
        {
            Debug.Log("Lo Preso:" + enemy.name);
            if (enemy.GetComponent<EnemyBaseHealt>() == null)
            {

            }
            else
            {
                enemy.GetComponent<EnemyBaseHealt>().TakeDamage(damage);
                enemy.GetComponent<EnemyStateController>().OnHurt();
                // enemy.GetComponent<EnemyStateController>().KnockbackMe(NumberAttack[index].KnockPosition, 10f);
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();


            }
        }

        meleeAttackSystem.isAttacking = false;

    }

    IEnumerator CastTimeing
        (int damage ,Action<int> action)
    {
        Debug.Log("Casting");
        yield return new WaitForSeconds(CastTime);
        action(damage);
        meleeAttackSystem.isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, AOERange);


    }
}



public enum MagicType{
   Shoot,
   AOE,
   Buff

}


public enum DirectionType
{

    Cursor,
    Unidirectional,
    Target,
}



