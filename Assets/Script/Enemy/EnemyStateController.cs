using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateController : MonoBehaviour
{

    Rigidbody2D RB;
    EnemyOnOff enemyMove;
    EnemyMovement enemyMove2;
   public bool isHurt=false;
    public float KnockBack;
    public float KnockBackLenght;
    public float KnockBackCount;
    EnemyBaseHealt enemyHealt;
    public GameObject StateImage;
    GameManager gameManager;
    [SerializeField]int index = 0;
    public bool isStunned = false;
    public bool isFirere = false;
    public bool isLowDefense = false;
    public StateEnemy stateEnemy;

    public List<int> StunTicks = new List<int>();
    public List<int> InfiammazioneTicks = new List<int>();
    public List<int> AvvelenamentoTicks = new List<int>();
    public List<int> LowerDefenseTiks = new List<int>();
    public List<int> RallentamentoTicks = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        RB=GetComponent<Rigidbody2D>();
        enemyMove = GetComponent<EnemyOnOff>();
        enemyMove2= GetComponent<EnemyMovement>();
        enemyHealt = GetComponent<EnemyBaseHealt>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
      
        
    }
    public void ChangeState(StateEnemy newState)
    {
        stateEnemy = newState;
    }
    void CreateIcon(GameObject iconInstantiate, int timer)
    {
        if (StateImage.transform.childCount <= 0)
        {
            index = 0;
        }
        if (StateImage.transform.childCount >= 1)
        {
            
           // Debug.Log(StateImage.transform.childCount);
            GameObject Debuffer = Instantiate(iconInstantiate, new Vector3(StateImage.transform.position.x, StateImage.transform.GetChild(index).position.y- 1.2f, 0f), Quaternion.identity);
            Debuffer.transform.SetParent(StateImage.transform);
            index++;
         
        }
        else
        {
            index = 0;
            GameObject Debuffer = Instantiate(iconInstantiate, StateImage.transform.position, Quaternion.identity);
            Debuffer.transform.SetParent(StateImage.transform);
            
        }
       
       
    }
    bool SearchIcon(GameObject icon) 
    
    {
       
        for (int i = 0; i < StateImage.transform.childCount; i++)
        {
            if (StateImage.transform.GetChild(i).name == icon.gameObject.name + "(Clone)")
            {
                Debug.Log("icona trovata");
                return false;
            }
        }
        Debug.Log("icona non trovata");
        return true;


    }

    void RemoveIcon(GameObject icon)
    {
        for (int i = 0; i < StateImage.transform.childCount; i++)
        {
            
            if (StateImage.transform.GetChild(i).name==icon.gameObject.name+"(Clone)")
            {
                Destroy(StateImage.transform.GetChild(i).gameObject);
                index--;
            }
            
         
        }

    }
    public void ApplyStateProblem(Debuff debuff,int Timer,int value) 
    {
        switch (debuff) {
            case Debuff.Avvelenamento:
                Debug.Log("avvelenato");
                if (SearchIcon(gameManager.AvvelenamentoIcon))
                {
                    CreateIcon(gameManager.AvvelenamentoIcon, Timer);
                }
                
                Positioned(value, Timer);
                break;

            case Debuff.Rallentamento:
                Debug.Log("Rallentato");
                CreateIcon(gameManager.RallentamentoIcon, Timer);
                break;

            case Debuff.RiduzioneDanni:
                Debug.Log("Meno Danni");
                CreateIcon(gameManager.RiduzioneDanniIcon, Timer);
                break;


            case Debuff.RiduzioneDifesa:
                LowDefense(value, Timer);
                Debug.Log("Riduzione difesa");
                if (SearchIcon(gameManager.RiduzioneDifesaIcon))
                {
                    CreateIcon(gameManager.RiduzioneDifesaIcon, Timer);
                }
                break;

            case Debuff.Stordimento:
                Debug.Log("Stordito");
                CreateIcon(gameManager.StunIcon, Timer);
                break;


            case Debuff.Scotttatura:
                if (SearchIcon(gameManager.InfiammazioneIcon))
                {
                    CreateIcon(gameManager.InfiammazioneIcon, Timer);
                }
                
                Ignite(value,Timer);
                break;

            case Debuff.Sanguinamento:
                Debug.Log("Sanguinamento");
                CreateIcon(gameManager.SanguinamentoIcon, Timer);
                break;
        }

    }
    // Update is called once per frame


    void LowDefense(int Amount,int Timer)
    {

        int newAmount = enemyHealt.Defense * 2* Amount / 100;
        
        Debug.Log(newAmount);
        
        if (LowerDefenseTiks.Count <= 0)
        {
            LowerDefenseTiks.Add(Timer);

            StartCoroutine(OnDefenseLow(newAmount));
        }
        else
        {
            AvvelenamentoTicks.Add(Timer);
        }
    }

    void Ignite(int Amount,int Timer)
    {
        {
            int LifeBurn = Amount / Timer;

            if (InfiammazioneTicks.Count <= 0)
            {
                InfiammazioneTicks.Add(Timer);

                StartCoroutine(OnIngnite(LifeBurn));
            }
            else
            {
                InfiammazioneTicks.Add(Timer);
            }
        }
    }
    IEnumerator OnIngnite(int AmountPerSecond)
    {
        while (InfiammazioneTicks.Count > 0)
        {
            for (int i = 0; i < AvvelenamentoTicks.Count; i++)
            {
                InfiammazioneTicks[i]--;
            }

            LoseHealt(AmountPerSecond);

            InfiammazioneTicks.RemoveAll(i => i == 0);

            yield return new WaitForSeconds(0.3f);

        }
        if (InfiammazioneTicks.Count == 0)
        {
            Debug.Log("termine avvelenamento");
            RemoveIcon(gameManager.InfiammazioneIcon);
        }




    }

    void Positioned(int LifeAmount , int Timer)
    {
        int LifePoision = LifeAmount / Timer;

        if (AvvelenamentoTicks.Count <= 0)
        {
            AvvelenamentoTicks.Add(Timer);

            StartCoroutine(OnPoisionedCounter(LifePoision));
        }
        else
        {
            AvvelenamentoTicks.Add(Timer);
        }
    }

    void LoseHealt(int Amount)
    {
        enemyHealt.LoseHealt(Amount);
    }

    IEnumerator OnPoisionedCounter(int AmountPerSecond)
    {
        while (AvvelenamentoTicks.Count > 0)
        {
            for (int i = 0; i < AvvelenamentoTicks.Count; i++)
            {
                AvvelenamentoTicks[i]--;
            }
            
            LoseHealt(AmountPerSecond);

            AvvelenamentoTicks.RemoveAll(i => i == 0);
           
            yield return new WaitForSeconds(1f);
            
        }
        if (AvvelenamentoTicks.Count == 0)
        {
            Debug.Log("termine avvelenamento");
            RemoveIcon(gameManager.AvvelenamentoIcon);
        }
       



    }

    IEnumerator OnDefenseLow(int Amount)
    {
        while (LowerDefenseTiks.Count > 0)
        {
            for (int i = 0; i < LowerDefenseTiks.Count; i++)
            {
                LowerDefenseTiks[i]--;
            }
            
            enemyHealt.Defense -= Amount;
            if (enemyHealt.Defense <= 2)
            {
                enemyHealt.Defense = 2;
            }
            LowerDefenseTiks.RemoveAll(i => i == 0);

            yield return new WaitForSeconds(1f);
        }
        if (LowerDefenseTiks.Count == 0)
        {
            Debug.Log("termine riduzione difesa");
            RemoveIcon(gameManager.RiduzioneDifesaIcon);
            enemyHealt.Defense = enemyHealt.OriginalDefense;
        }
        

    }
    void Update()
    {
        if (KnockBackCount >= 0)
        {
            KnockBackCount -= Time.deltaTime;
           
        }
        
    }
    public void KnockbackMe(Vector2 direction,bool flipped)
    {
        // RB.isKinematic = false;
        if (!flipped)
        {
            RB.velocity = Vector2.zero;
            RB.AddForce(direction * 10, ForceMode2D.Force);
            Debug.Log(direction);
          
        }
        if (flipped)
        {
            RB.velocity = Vector2.zero;
            direction = -direction;
            RB.AddForce(direction * -10*Time.deltaTime, ForceMode2D.Force);
          
        }
       
       
    }
    public void KnockbackMe(float duration)
    {
        KnockBackCount = duration;


       
            enemyMove2.Stop = true;
          
            if (enemyMove2.Flipped)
            {
           
            RB.velocity = new Vector2(-KnockBack, KnockBack - 2);
        }
            if (!enemyMove2.Flipped)
            {
          
             RB.velocity = new Vector2(KnockBack, KnockBack+2);
        }
           // KnockBackCount -= Time.deltaTime;
        //Invoke("UnKnock", KnockBackLenght);

        Invoke("UnKnock", duration);

        //  RB.AddForce(-position * Force, ForceMode2D.Impulse);
        /*
        if (enemyMove.Flipped == true)
        {
            RB.isKinematic = false;
            
        }
        else
        {
            RB.isKinematic = false;
            RB.AddForce(position * Force);
        }
        */
    }

    public void OnHurt()
    {
        isHurt = true;
        Invoke("UnHurt", 0.5f);
    }
    void UnHurt() => isHurt = false;
    void UnKnock()
    {
        enemyMove2.Stop = false;
        KnockBackCount = 0;
    }
}

public enum StateEnemy
{
    Idle,
    AttackPlayer,
    AttackFountain,
    ChasePlayer,
    ChaseFountain
}