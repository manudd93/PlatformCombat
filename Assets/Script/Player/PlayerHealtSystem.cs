using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealtSystem : MonoBehaviour
{
    public float Healt=100f;
    public float maxBar=100f;
    public float MaxHealt=100f;
    public bool IamDead=false;
     public Image HealBar;
       public TextMeshProUGUI HealtText;
        public TextMeshProUGUI MaxHealtText;
       public Animator anim;
    PlayerStateController playerStateController;
    PlayerMovevement playerMovevement;
public Sprite[] FaceHealt;
public Image Face;
public static PlayerHealtSystem Instance{get;private set;}
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        maxBar = MaxHealt;
        Healt =maxBar;
       
       Face=GameObject.FindGameObjectWithTag("Face").GetComponent<Image>();
        HealtText=GameObject.FindGameObjectWithTag("HealtText").GetComponent<TextMeshProUGUI>();
        MaxHealtText= GameObject.FindGameObjectWithTag("MaxHealtText").GetComponent<TextMeshProUGUI>();
        HealBar =GameObject.FindGameObjectWithTag("HealtBar").GetComponent<Image>();
        HealtText.text=Healt.ToString();
        playerStateController = GetComponent<PlayerStateController>();
        playerMovevement=GetComponent<PlayerMovevement>();
        MaxHealtText.text = "/"+MaxHealt.ToString();
     if(Healt>=MaxHealt){
    Face.sprite=FaceHealt[0];
}
    }

    // Update is called once per frame
    void Update()
    {
        if(Healt<=0){
            Destroy(this.gameObject);
        }
    }


    public void RecoverHealt(int Amount){
        
Healt+=Amount;
if(Healt>=MaxHealt){
    Healt=MaxHealt;
}
  HealBar.fillAmount=Healt/maxBar;
   HealtText.text=Healt.ToString();

if(Healt>=30){
    Face.sprite=FaceHealt[4];
}
if(Healt>=40){
    Face.sprite=FaceHealt[3];
}
if(Healt>=60){
    Face.sprite=FaceHealt[2];
}
if(Healt>=80){
    Face.sprite=FaceHealt[1];
}
if(Healt==MaxHealt){
    Face.sprite=FaceHealt[0];
}





    }
    public void LevelUp(int newHealt,int recoverHealt)
    {
        
        Healt += recoverHealt;
        MaxHealt += newHealt;
        maxBar = MaxHealt;
        if (Healt > MaxHealt)
        {
            Healt = MaxHealt;
        }
        HealBar.fillAmount = Healt / maxBar;
        MaxHealtText.text = "/" + MaxHealt.ToString();
        HealtText.text = Healt.ToString();
       


    }
    public void TakeDamage(int Damage){


        if (playerStateController.invincible == true)
        {
            Debug.Log("INVINCIBILITY"); 
            return;
        }
//        Debug.Log("Danni Presi:"+Damage.ToString());
        DamagePopUp.Create(this.transform.position,Damage);
        Healt-=Damage;


        // anim.SetTrigger("Hurt");

        //playerStateController.HurtPlayer();
        //PlayerStateController.ChangeState(StatePlayer.Hurting);
   HealBar.fillAmount=Healt/maxBar;
   HealtText.text=Healt.ToString();
if(Healt>=MaxHealt){
    Face.sprite=FaceHealt[0];
}
if(Healt<=80){
    Face.sprite=FaceHealt[1];
}

if(Healt<=60){
    Face.sprite=FaceHealt[2];
}
if(Healt<=40){
    Face.sprite=FaceHealt[3];
}
if(Healt<=30){
    Face.sprite=FaceHealt[4];
}
if(Healt<=0){
    Face.sprite=FaceHealt[5];
}

   
}

}
