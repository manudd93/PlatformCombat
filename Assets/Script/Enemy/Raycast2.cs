
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2 : MonoBehaviour
{
    public Transform EyeRay;
    public float EyeLong;
    StartChase ChaseScript;
    // Start is called before the first frame update
    void Start()
    {
         ChaseScript=GameObject.FindObjectOfType<StartChase>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Eye2=Physics2D.Raycast(EyeRay.transform.position,Vector2.right,EyeLong);
 if(Eye2.collider !=null){
            if(Eye2.collider.tag=="Player"){
                 ChaseScript.isChasing=true;
                  Debug.Log(" ti vedo2");
                  Debug.DrawLine(transform.position,Eye2.point,Color.red);
            }

    }else
    {
        Debug.DrawRay(transform.position,Vector2.right*EyeLong,Color.green);
     // Debug.DrawRay(transform.position,Eye2.point,Color.green);
        Debug.Log("non ti vedo2");
    }
    
    }
}
