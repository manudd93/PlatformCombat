using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrasformationManager : MonoBehaviour
{
    
    public static  bool DemonForm = false;
    public static bool AngelForm=false;
    bool CantSwitchDemon = false;
    public GameObject Human;
    public GameObject Demon;
      public GameObject Angel;
    
    public float Power = 100f;
    public float maxBar = 100f;
    public float MaxPower = 100f;
   
    public Image PowerBar;
    // Start is called before the first frame update
    void Start()
    {
        PowerBar.fillAmount = Power / maxBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void AddPower(int PowerAmount)
    {
        Power += PowerAmount;
        PowerBar.fillAmount = Power / maxBar;
    }

    public void RemovePower(int PowerAmount)
    {
        Power -= PowerAmount;
        PowerBar.fillAmount = Power / maxBar;
    }

    public  void StartTrasformation()
    {
        
      if(CantSwitchDemon==false)
        {

            StartCoroutine(BeginTraformation());
            

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sigillo")
        {
            Debug.Log("zona proibita");
            CantSwitchDemon = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sigillo")
        {
            CantSwitchDemon = false;
        }
    }
    public  void RemoveTraformation()
    {
        DemonForm = true;
    }

    public IEnumerator BeginTraformation()
    {
        
        yield return new WaitForSeconds(0.8f);
        DemonForm = !DemonForm;
        if (DemonForm == true)
        {
            Human.gameObject.SetActive(false);
            Demon.gameObject.SetActive(true);
            CameraScript.SwitchCameraPlayer(true);
            Demon.transform.position = Human.transform.position;
        }
        else
        {
            Human.gameObject.SetActive(true);
            Demon.gameObject.SetActive(false);
            CameraScript.SwitchCameraPlayer(false);
            Human.transform.position = Demon.transform.position;
        }
       
        
    }

   
}
