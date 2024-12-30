using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class GrabberItem : MonoBehaviour
{

     public Text textalert;
    public static event Action<int> IstantItemPick;

    public GameObject SwordTranformation;
    public GameObject MagicSlotItem;
    ItemDatabase itemDatabase;
    public GameObject WeaponSlot;
    public GameObject MagicSlot;
    public GameObject ItemSlot;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        itemDatabase = GameObject.FindObjectOfType<ItemDatabase>();
        scoreManager=GameObject.FindObjectOfType<ScoreManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weapon")
        {

        }
    }

     void OnTriggerStay2D(Collider2D col)
    {
    
        if (col.gameObject.tag == "Weapon")
        {
            textalert.text = "Raccogli " + col.GetComponent<IdWeapon>().weaponId.WeaponName;
            if (Input.GetKey(KeyCode.E) && TrasformationManager.DemonForm == true)
            {
                for(int i = 0; i > SwordTranformation.transform.childCount; i++)
                {
                    SwordTranformation.transform.GetChild(i).gameObject.SetActive(false);
                }
                if (WeaponSlot.transform.childCount != 0)
                {
                    try
                    {
                        Destroy(WeaponSlot.transform.GetChild(1).gameObject);
                    }
                    catch (Exception e)
                    {

                    }
                      

                }
                GameObject NewWeapon = Instantiate(itemDatabase.Lista_Armi_IconeInInventory[col.GetComponent<IdWeapon>().weaponId.ID], WeaponSlot.transform.position, Quaternion.identity);;

                NewWeapon.transform.SetParent(WeaponSlot.transform,true) ;
                Destroy(col.gameObject);
            }
        }
        if (col.gameObject.tag == "IstantItem")
        {
            Debug.Log(col.GetComponent<IstantItem>().ID_Item.ID+ " " + col.GetComponent<IstantItem>().ID_Item.Name);
            IstantItemPick?.Invoke(col.GetComponent<IstantItem>().ID_Item.ID);
            if(col.GetComponent<IstantItem>().ID_Item.Name=="ExpBall"){
                
                ExperienceManager.Instance.AddExperience(col.GetComponent<IstantItem>().ID_Item.value);
          
          GameManager.Instance.PlayOneShotSound(col.GetComponent<IstantItem>().ID_Item.SFXSound);
            }
            if(col.GetComponent<IstantItem>().ID_Item.Name=="DemonBlood"){
      scoreManager.AddDemonBlood(col.GetComponent<IstantItem>().ID_Item.value);
            }
                   if(col.GetComponent<IstantItem>().ID_Item.Name=="RedPot"){
      GameManager.Instance.PlayOneShotSound(col.GetComponent<IstantItem>().ID_Item.SFXSound);
      PlayerHealtSystem.Instance.RecoverHealt(col.GetComponent<IstantItem>().ID_Item.value);
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Magic")
        {
            textalert.text = "Raccogli " + col.GetComponent<IdMagic>().magicScripable.MagicName;
            if (Input.GetKey(KeyCode.E) && TrasformationManager.DemonForm == true)
            {
                for (int i = 0; i > MagicSlotItem.transform.childCount; i++)
                {
                  //  SwordTranformation.transform.GetChild(i).gameObject.SetActive(false);
                }
                if (MagicSlot.transform.childCount != 0)
                {
                    try
                    {
                        Destroy(MagicSlot.transform.GetChild(1).gameObject);
                    }
                    catch (Exception e)
                    {

                    }


                }
                GameObject NewWeapon = Instantiate(itemDatabase.Lista_Magie_IconeInInventory[col.GetComponent<IdMagic>().magicScripable.ID], MagicSlot.transform.position,Quaternion.identity); ;

                NewWeapon.transform.SetParent(MagicSlot.transform);
                Destroy(col.gameObject);
            }
        }


    }

    private void OnTriggerExit2D(Collider2D col)
    {
        textalert.text = "";
       // textalert.CallStopAlert();
    }
}
