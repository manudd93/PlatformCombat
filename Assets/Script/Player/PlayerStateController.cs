using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public  bool isHurt = false;
    public bool invincible = false;
    public  static bool CantMoveAndAttack= false;
    public float timingHurt;
    public float TimerCase = 0.0f;
   public StatePlayer CurrentStatus;
    public static StatePlayer playerState;
    
    public static void ChangeState(StatePlayer newState)
    {
        playerState = newState;
    

    }

    public static StatePlayer GetState()
    {
        return playerState;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentStatus = playerState;
        if (TimerCase > 0)
        {
            TimerCase -= Time.deltaTime;
            CantMoveAndAttack = false;
        }
    }

    
    public void KnockBackMe()
    {


    }
        public  void HurtPlayer()
    {
        isHurt = true;
        Invoke("StopHurt", 1f);
        //Invincibility(1f);
        CustomAnimator.PlayAnimationState("PlayerHurt");
        
    
    }

    public void CastingSpell(int Timer)
    {
        CantMoveAndAttack = true;

        TimerCase = Timer;
    }

    void StopHurt()
    {
        isHurt = false;
    }

    public void Invincibility(float timer)
    {
        invincible = true;
        Invoke("StopInvicibility", timer);

    }

    void StopInvicibility()
    {
        invincible = false;
    }
}

public enum StatePlayer{
    Idle,
    Walking,
    Attacking,
    Jumping,
    Stunning,
    Hurting,
    Casting


}
