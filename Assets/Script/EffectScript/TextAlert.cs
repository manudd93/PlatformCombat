using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextAlert : MonoBehaviour
{
    public  Text EventText;
    public void CallAlert(string Message,bool timed,float timer)
    {
        if (timed)
        {
            EventText.text = Message;
            Invoke("CallStopAlert", timer);
        }
        else
        {
 EventText.text = Message;
        }
       
        
    }



   public   void CallStopAlert()
    {
        EventText.text = "";
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
