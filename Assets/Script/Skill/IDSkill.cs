using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSkillBro", menuName = "Crea Nuova Abilità")]
public class IDSkill : ScriptableObject
{
    
    public int ID;
    public string Nome;
public AudioClip SFX;
public AnimationClip AnimClip;
public Sprite IconImage;
public float CoolDown;
public int Damage;
public int MinDamage;
public int MaxDamage;
public bool CanCharge;
    public float Range;
public bool AoeDamage;
public float KnockBack=0;

public float maxTimeCharge;

}
