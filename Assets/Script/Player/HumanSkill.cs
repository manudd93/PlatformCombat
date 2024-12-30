using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanSkill : MonoBehaviour
{
    
    public Image SlotSkill;
    public Image reloadBarSkill;
    public IDSkill Abilità;
    public Transform AttackPoint;
    public LayerMask mask;
    MeleeAttackSystem meleeAttackSystem;
    public float ChargedTime = 0f;
    public float MaxChargedTime;
    public KeyCode keyBinding;
    ChangeColorSprite changeColorSprite;
    float coolDownCurrent;
    bool Reload;
   public bool IsClicked = false;
    public int OutputDamage;
   

    public float firerate = 1.1f;
    float nextfire = 0.0f;
 void Start() {
    SlotSkill.sprite=Abilità.IconImage;
        firerate = Abilità.CoolDown;
        this.MaxChargedTime = Abilità.maxTimeCharge;
        changeColorSprite = GetComponentInParent<ChangeColorSprite>();
        meleeAttackSystem = GameObject.FindObjectOfType<MeleeAttackSystem>();
        
    }


    void Update()
    {
        if (Reload)
        {
            reloadBarSkill.fillAmount = coolDownCurrent/Abilità.CoolDown;
            coolDownCurrent -= Time.deltaTime;
            if (coolDownCurrent <= 0)
                Reload = false;

            
        }

        if (Input.GetKey(keyBinding))
            IsClicked = true;
         else 
            IsClicked = false;

        if (!IsClicked && PlayerStateController.GetState() ==  StatePlayer.Attacking && IsClicked)
        {
            RelaseCharge();
        }

        if (Input.GetKey(keyBinding) && Time.time > nextfire && IsClicked)
        {
            ActiveSkill();
            
        }
        if (Abilità.CanCharge && PlayerStateController.GetState() == StatePlayer.Attacking && Reload==false)
        {
            if (Input.GetKeyUp(keyBinding) )
            {
               
                RelaseCharge();


           
            }
        }

        //if (Input.GetKey(KeyCode.H))
        //{
        //                       changeColorSprite.StartDiscolight(0.2f, GetComponentInParent<SpriteRenderer>(), Color.HSVToRGB(0, 100, 100), Color.HSVToRGB(8,97,44,true), 0.05f);

            
        //}

    }
    void RelaseCharge()
    {
        if (PlayerStateController.GetState() == StatePlayer.Attacking)
        {
            CustomAnimator.anim.speed = 1;
            CustomAnimator.PlayAnimationState(Abilità.AnimClip.name);
           
         
           


            float newDamage = Abilità.MinDamage + ChargedTime * 10;
            int NewDamage = Mathf.RoundToInt(newDamage);
            Debug.Log(NewDamage);
            ChargedTime = 0f;
            nextfire = Time.time + firerate;

            OutputDamage = NewDamage;
            changeColorSprite.StopDiscolight();
            StartCoolDown();


        }
    }

    void StartCoolDown()
    {
        reloadBarSkill.fillAmount = Abilità.CoolDown;
        coolDownCurrent = Abilità.CoolDown;
        Reload = true;
       
    }

    public void FinishSkill()
    {
        //meleeAttackSystem.isAttacking = false;
        PlayerStateController.ChangeState(StatePlayer.Idle);
    }
void ActiveSkill(){

        if (Abilità.ID == 0)
        {
            if (Abilità.CanCharge)
            {
                //CustomAnimator.anim.Play(Abilità.AnimClip.name, 0, 0.5f);
                
               // CustomAnimator.anim.PlayInFixedTime(Abilità.AnimClip.name, 0, 0.5f);
                //CustomAnimator.anim.speed = 0;
                    meleeAttackSystem.isAttacking = true;
                PlayerStateController.ChangeState(StatePlayer.Attacking);
                changeColorSprite.StartDiscolight(0.2f, GetComponentInParent<SpriteRenderer>(), new Color(0.6693884f, 0.8301887f, 0.1292275f), new Color(0.9245283f, 0.847756f, 0.3619615f), 0.05f);
                CustomAnimator.PlayAnimationState(Abilità.AnimClip.name);
               // CustomAnimator.anim.speed += Time.time/20;
                ChargedTime += Time.deltaTime;
              
                    if (ChargedTime >= MaxChargedTime)
                    {
                        ChargedTime = MaxChargedTime;
                    RelaseCharge();
                    }
                }

            
        }
           
        }

    public void StopAnimation()
    {
        CustomAnimator.anim.speed = 0;
    }

    public void Reset()
    {
        //meleeAttackSystem.isAttacking = false;
        PlayerStateController.ChangeState(StatePlayer.Idle);
    }
    public void ExecuteMeleeAttack(float range,bool AOE,LayerMask mask,Transform attackPosition,float IntensityShake,float timerShake,int damage) {

        if (AOE)
        {
            attackPosition.position = transform.localPosition;
        }
        Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(attackPosition.position, range, mask);
        meleeAttackSystem.AddForce(20f);

        foreach (Collider2D enemy in HitEnemy)
        {

            if (enemy.GetComponent<EnemyBaseHealt>() != null)
            {
                enemy.GetComponent<EnemyBaseHealt>().TakeDamage(damage);

             

                CinemachineShake.Instance.ShakeCamera(IntensityShake, timerShake);
               
            }
            else
            {


                return;

            }

        }
        
    }




}

public enum HumanTypeSkill
{
PugnoCaricato,
CalcioRotante,

DoppioSchiaffoCaricato,

RafficaCatena,

Presa,


}
