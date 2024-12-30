using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseHealt : MonoBehaviour
{
    Rigidbody2D rb;
    public float Healt=100f;
   // public Animator anim;
    public GameObject EffectBlood;
     public GameObject EffectBloodDie;
    public float maxBar=100f;
    public float MaxHealt=100f;
    public int Defense;
    public int OriginalDefense;
     public Image HealBar;
     public GameObject BarSetActive;
   public  Patrol patrol;
   public bool isPatrolling=false;
   public bool OnDefenseMode=false;
    public bool Immortality = false;
    EnemyMovement enemyMovement;
    [SerializeField]
    EnemyLootScript enemyLootScript;
    ChangeColorSprite changeColorSprite;
  
   
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyLootScript = GetComponent<EnemyLootScript>();
        changeColorSprite = GetComponent<ChangeColorSprite>();
        OriginalDefense = Defense;
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
 
    public int CalculateDefense(int damageIn, int defense)
    {
         int newDamage = damageIn * damageIn / (damageIn + defense);
       // int newDamage = (100 * damageIn) / (defense + 100);
        return newDamage;
    }


    public void LoseHealt(int amount)
    {
        Healt -= amount;
        HealBar.fillAmount = Healt / maxBar;
        DamagePopUp.Create(this.transform.position, amount);
    }

    public void RecoverHealt(int amount)
    {
        Healt += amount;
        HealBar.fillAmount = Healt / maxBar;
       // DamagePopUp.Create(this.transform.position, amount);
    }
    public void TakeDamage(int Damage){
    
        if(OnDefenseMode==false){
        if(enemyMovement !=null){
        if(enemyMovement.movementType==MovementType.Patrolling){
        
 enemyMovement.Hurting();
                    changeColorSprite.StartDiscolight(0.2f, GetComponentInParent<SpriteRenderer>(), new Color(0.8490566f, 0.1117658f, 0f), new Color(0.9433962f, 0.5935032f, 0f), 0.05f);
                }
            }

              
            rb.velocity=Vector3.zero;
       int OutPutDamage= CalculateDefense(Damage, Defense);
            Healt -= OutPutDamage;
       HealBar.fillAmount=Healt/maxBar;
       //anim.SetTrigger("Hurt");
            DamagePopUp.Create(this.transform.position, OutPutDamage);
            Instantiate(EffectBlood ,transform.position,Quaternion.identity);
       
         if(Healt< MaxHealt){
           BarSetActive.SetActive(true);
        }else{
            BarSetActive.SetActive(false);
        }
            if (Healt <= 0)
            {


                 Destroy(this.gameObject
                     );
                
                    enemyLootScript.SpawnItem();
                   

            }
        }
        else{
       
        
     Damage=Damage*20/100;
      Healt-=Damage;
       HealBar.fillAmount=Healt/maxBar;
           
       
       
         if(Healt< 100f){

           BarSetActive.SetActive(true);

        }else{
            BarSetActive.SetActive(false);
        }
    }
        if (Immortality)
        {
            Healt = MaxHealt;
            HealBar.fillAmount = Healt;
        }
    }


}
