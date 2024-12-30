using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager:MonoBehaviour
{
    Inventory inventory;
  public static GameManager Instance{get;set;}
    public Transform SpawnPoint;
    public GameObject Player;
    public GameObject CameraPlayer;
    public GameObject CameraSpectate;
    public GameObject damagePop;
    public GameObject StunIcon;
    public GameObject InfiammazioneIcon;
    public GameObject RallentamentoIcon;
    public GameObject RiduzioneDanniIcon;
    public GameObject RiduzioneDifesaIcon;
    public GameObject AvvelenamentoIcon;
    public GameObject SanguinamentoIcon;
    AudioSource audioSource;
    void Awake(){

 Instance = this;
    }
    public GameObject InventoryCanvas;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.I) &&  InventoryCanvas.gameObject.activeSelf==false){
  InventoryCanvas.gameObject.SetActive(true);

        }else if(Input.GetKeyDown(KeyCode.I) &&  InventoryCanvas.gameObject.activeSelf==true){
              InventoryCanvas.gameObject.SetActive(false);
              
        }

    
    }

public void ChangePowerType(string name){
    switch(name){
        case  "Sword":
        Debug.Log("AttivoSpadainCulo");
    break;

    case "Shield":
    Debug.Log("AttivoScudoDimmerda");
    break;
    case "Heart":
    Debug.Log("melomettoinculo");
    break;
    }

   
}






public void PlayOneShotSound(AudioClip audio){
  
audioSource.PlayOneShot(audio);
}

}
