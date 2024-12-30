using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    public static Animator anim;
    HumanSkill humanSkill;
    // Start is called before the first frame update
    void Start()
    {
        humanSkill = GetComponentInChildren<HumanSkill>();
    }
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayAnimationState(string newState)
    {
        anim.Play(newState);
    }

    public void TriggerSkill()
    {
        humanSkill.ExecuteMeleeAttack(humanSkill.Abilità.Range, false, humanSkill.mask, humanSkill.AttackPoint,4f,0.3f, humanSkill.OutputDamage);
    }

    public void StopAnimationSkill()
    {
        humanSkill.StopAnimation();
    }

    public void Reset()
    {
        humanSkill.Reset();
    }



}
