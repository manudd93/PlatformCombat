using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerChar : MonoBehaviour
{
    public int HealtPercentageGrow,DamageGrow,MoveSpeedGrow, CurrentExperience, maxExperience, currentLevel;
    public Image ExpBar;
    PowerSelectionManager powerSelectionManager;
   [SerializeField] TextMeshProUGUI textLv;
    MeleeAttackSystem meleeAttackSystem;


    private void Start()
    {
        ExpBar = GameObject.FindGameObjectWithTag("ExpBar").GetComponent<Image>();
        textLv = GameObject.FindGameObjectWithTag("TextLV").GetComponent<TextMeshProUGUI>();
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
        meleeAttackSystem = GetComponentInChildren<MeleeAttackSystem>();

        powerSelectionManager = GetComponent<PowerSelectionManager>();

    }
    private void OnEnable()
    {
   
    }
    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }
    private void HandleExperienceChange(int newExperience)
    {
        CurrentExperience += newExperience;
       
      
        ExpBar.fillAmount = (float)CurrentExperience / (float)maxExperience;
        if (CurrentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel += 1;
        textLv.text = currentLevel.ToString();
        CurrentExperience = 0;
        maxExperience += 30;
        ExpBar.fillAmount = 0;
        PlayerHealtSystem.Instance.LevelUp(CalculateNewHealt(), CalculateRecoverHealt());
        meleeAttackSystem.LevelUp(CalculateDamageGrow());
        powerSelectionManager.StartSelection();

    }

    private int CalculateNewHealt()
    {
        int newHealt;
       newHealt= HealtPercentageGrow + currentLevel;
        return newHealt;
    }
    private int CalculateRecoverHealt()
    {
        float newRecoverHealt=HealtPercentageGrow+currentLevel/2;
       
        return (int)newRecoverHealt;
    }
    private int CalculateDamageGrow()
    {
        int newDamage = DamageGrow+currentLevel /2;
        Debug.Log(newDamage);
        return newDamage;
    }
    
}
