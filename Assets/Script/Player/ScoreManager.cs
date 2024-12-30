using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance{get;private set;}

    int BloodDemon;
    int BloodAngel;
     public TextMeshProUGUI BloodAngelText;
        public TextMeshProUGUI BloodDemonText;
    void Start()
    {
        
    }

    // Update is called once per frame
 

    public void AddAngelBlood(int amount){
    BloodAngel += amount;
    BloodAngelText.text= BloodAngel.ToString();
    }

    public void AddDemonBlood(int amount){
            BloodDemon += amount;
    BloodDemonText.text= BloodDemon.ToString();
    }
}
