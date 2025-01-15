using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelectionManager : MonoBehaviour
{
    public GameObject showPanelSelection;
    public Button[] buttonSelection;
 


    public List<Skill> availableSkills = new List<Skill>();
    private List<Skill> currentSkillChoices;
    PowerManager powerManager;
    // Start is called before the first frame update
    void Start()
    {
        powerManager = GetComponent<PowerManager>();
    }
    public void StartSelection()
    {
        showPanelSelection.SetActive(true);
        Time.timeScale = 0f;
        GenerateRandomSkill();
        UpdateSkill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CloseLevelUpPanel()
    {
        showPanelSelection.SetActive(false);
        Time.timeScale = 1f;


    }

    private void GenerateRandomSkill()
    {
        currentSkillChoices = new List<Skill>();

        // Crea una copia temporanea della lista disponibile per evitare duplicati
        List<Skill> tempSkills = new List<Skill>(availableSkills);
        

        for (int i = 0; i < buttonSelection.Length; i++)
        {
            if (tempSkills.Count > 0)
            {
                int randomIndex = Random.Range(0, tempSkills.Count);
                Skill randomSkill = tempSkills[randomIndex];
                currentSkillChoices.Add(randomSkill);
                tempSkills.RemoveAt(randomIndex); // Rimuove la skill scelta per evitare duplicati
            }
        }
    }

    private void UpdateSkill()
    {
        for (int i = 0; i < buttonSelection.Length; i++)
        {
            if (i < currentSkillChoices.Count)
            {
                buttonSelection[i].gameObject.SetActive(true); // Assicura che il pulsante sia visibile
                Text[] textButton = buttonSelection[i].GetComponentsInChildren<Text>();
                currentSkillChoices[i].Level += 1;
                textButton[0].text = currentSkillChoices[i].skillName;
                textButton[1].text = currentSkillChoices[i].description;
                textButton[3].text = currentSkillChoices[i].Level.ToString();
                 
                if (currentSkillChoices[i].classType == ClassType.Berserker)
                {
                    
                    var parentObject = textButton[i].GetComponentsInParent<Image>();
                    Debug.Log(parentObject[1].gameObject.name);
                    parentObject[1].color = Color.red;
                    
                }
                if (currentSkillChoices[i].classType == ClassType.Base)
                {
                    var parentObject = textButton[i].GetComponentsInParent<Image>();
                    Debug.Log(parentObject[1].gameObject.name);
                    parentObject[1].color = Color.cyan;
                }
                if (currentSkillChoices[i].classType == ClassType.Gunfight)
                {
                    var parentObject = textButton[i].GetComponentsInParent<Image>();
                    Debug.Log(parentObject[1].gameObject.name);
                    parentObject[1].color = Color.green;
                }
                if (currentSkillChoices[i].classType == ClassType.Tekno)
                {
                    var parentObject = textButton[i].GetComponentsInParent<Image>();
                    Debug.Log(parentObject[1].gameObject.name);
                    parentObject[1].color = Color.blue;

                }
                //buttonSelection[i].GetComponentInChildren<Text>().text = currentSkillChoices[i].skillName; // Mostra il nome della skill
                int index = i; // Importante per evitare problemi di chiusura su lambda
                buttonSelection[i].onClick.RemoveAllListeners();
                buttonSelection[i].onClick.AddListener(() => ChooseSkill(index)); // Assegna la funzione con l'indice corretto
            }
            else
            {
                buttonSelection[i].gameObject.SetActive(false); // Nasconde i pulsanti inutilizzati
            }
        }
    }
    public void ChooseSkill(int skillIndex)
    {
        if (skillIndex >= 0 && skillIndex < currentSkillChoices.Count)
        {
            Skill chosenSkill = currentSkillChoices[skillIndex];
            Debug.Log("Hai scelto la skill: " + chosenSkill.skillName);

            // Applica l'effetto della skill
            ApplySkillEffect(chosenSkill);
        }

        // Chiude la finestra
        CloseLevelUpPanel();
    }

    private void ApplySkillEffect(Skill skill)
    {
        switch (skill.effectType)
        {
            case SkillEffectType.Vita:
                IncreaseHealth();
                break;
            case SkillEffectType.Danno:
                IncreaseAttack();
                break;
            case SkillEffectType.Velocita:
                IncreaseSpeed();
                break;

            case SkillEffectType.Critico:
                Critico();
                break;
            case SkillEffectType.Fucilata:
                Fucile();
                break;
            case SkillEffectType.Incendio:
                Incendio();
                break;
            case SkillEffectType.Range:
                Range();
                break;
            case SkillEffectType.Rigenerazione:
                Regeneration();
                break;
            case SkillEffectType.Miss:
                Miss();
                break;
            case SkillEffectType.Assistente:
                SummonFriend();
                break;
            case SkillEffectType.DoubleJump:
                DoubleJump();
                break;
            case SkillEffectType.DroneLaser:
                SummonDrone();
                break;
            case SkillEffectType.HeavyMachineGun:
                AssaultRifle();
                break;
            case SkillEffectType.RiduciDifesa:
                DefenseLow();
                break;
            case SkillEffectType.SparaPalleDifuoco:
                FireBall();
                break;
            case SkillEffectType.SuperPugno:
                SuperPunch();
                break;
            case SkillEffectType.Terremoto:
                Terremoto();
                break;
            case SkillEffectType.Revolver:
                Revolver();
                break;
           
            default:
                Debug.LogWarning("Tipo di effetto non definito");
                break;
        }
    }

    // Esempi di potenziamenti che il giocatore può scegliere
    private void IncreaseHealth()
    {
        Debug.Log("Salute aumentata!");
        powerManager.AddLife();
        // Inserisci qui la logica per aumentare la salute
    }

    private void IncreaseAttack()
    {
        Debug.Log("Attacco aumentato!");
        powerManager.AddDamage();
        // Inserisci qui la logica per aumentare l'attacco
    }

    private void IncreaseSpeed()
    {
        Debug.Log("Velocità aumentata!");
        // Inserisci qui la logica per aumentare la velocità
    }

    void Regeneration()
    {
        Debug.Log("rigenerazione");
    }

    void Incendio()
    {
        Debug.Log("ora puoi incendiare i tuoi nemici ");
    }
    void Fucile()
    {
        Debug.Log("Ora puoi sparare un colpo di fucile");
    }

    void Critico()
    {
        Debug.Log("ora puoi crittare");
    }

    void Miss()
    {
        Debug.Log("ora puoi missare ");
    }

    void Range()
    {
        Debug.Log("aumento range");
    }

    void SummonFriend()
    {
        Debug.Log("Amico chiamato");


    }

    void DoubleJump()
    {
        Debug.Log("doppio salto");
    }

    void SummonDrone()
    {
        Debug.Log("drone attivato");
    }

    void AssaultRifle()
    {
        Debug.Log("fucile di assalto ");
    }

    void DefenseLow()
    {
        Debug.Log("ora puoi ridurre difesa");
    }
    void FireBall()
    {
        Debug.Log("ora puoi lanciare palla di fuoco");
    }

    void SuperPunch()
    {
        Debug.Log(" super pugno");
    }
    void Terremoto()
    {
        Debug.Log("terremoto");
    }

    void Revolver()
    {
        Debug.Log("revolver attiva");
    }
}

[System.Serializable]
public class Skill
{
    public string skillName; // Nome della skill
    public string description;
    public int Level;
    public int MaxLevel;
    public SkillEffectType effectType; // Tipo di effetto della skill
    public ClassType classType;

}
public enum ClassType
{
    Base,
    Berserker,
    Gunfight,
    Tekno
    
}

public enum SkillEffectType
{
    Vita,
    Danno,
    Velocita,
    Rigenerazione,
    Range,
    Critico,
    Incendio,
    Fucilata,
    Miss,
    SuperPugno,
    Terremoto,
    GrabEnemy,
    RiduciDifesa,
    Revolver,
    HeavyMachineGun,
    DoubleJump,
    DroneLaser,
    SparaPalleDifuoco,
    Assistente

    
}
