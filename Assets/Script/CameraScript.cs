using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
      private float xMax;
     [SerializeField]
    private float yMax;
     [SerializeField]
    private float xMin;
     [SerializeField]
    private float yMin;
 public Transform Target;
    public GameObject DemonPlayer;
 public GameObject Player;
 
 
 static bool switchForm=false;

 
    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void Update()
    {
        if (switchForm == true)
        {
            Target = DemonPlayer.transform;
        }
        else
        {
            Target = Player.transform;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     
       transform.position=new Vector3(Mathf.Clamp(Target.transform.position.x,xMin,xMax),Mathf.Clamp(Target.transform.position.y,yMin,yMax),transform.position.z);

    }
    public static void SwitchCameraPlayer(bool selectform)
    {
        if (selectform == true)
        {
            switchForm = true;
        }
        else
        {
            switchForm = false;
        }
    }
}


