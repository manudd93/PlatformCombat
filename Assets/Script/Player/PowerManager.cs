using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    PlayerStateController playerStateController;
    PlayerController playerController;
    PlayerMovevement playerMovevement;
    PlayerHealtSystem playerHealtSystem;
    MeleeAttackSystem meleeAttackSystem;
    [SerializeField] int AmountHealt;
    [SerializeField] int AmountDamage;
    [SerializeField] float AmountMoveSpeed;
    private void Awake()
    {
        playerHealtSystem = GetComponent<PlayerHealtSystem>();
        playerController = GetComponent<PlayerController>();
        playerHealtSystem = GetComponent<PlayerHealtSystem>();
        meleeAttackSystem = GetComponentInChildren<MeleeAttackSystem>();
        playerMovevement = GetComponent<PlayerMovevement>();
    }
    public void AddLife()
    {
        playerHealtSystem.addHealt(AmountHealt);
    }

    public void AddDamage()
    {
        meleeAttackSystem.IncreaseDamage(AmountDamage);
    }

    public void AddMoveSpeed()
    {
        playerMovevement.AddMoveSpeed(AmountMoveSpeed);
    }
}
