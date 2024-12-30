using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public float speedRotate;
     Quaternion spreadAngleNegative =  Quaternion.AngleAxis(-60.0f, new Vector3(1, 0, 0));
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speedRotate*Time.deltaTime);
    RaycastHit2D rayinfo=Physics2D.Raycast(transform.position,transform.right,10f);
    if(rayinfo.collider !=null){

         Debug.DrawLine (transform.position,rayinfo.point , Color.blue);
    }else{
        Debug.DrawLine (transform.position,transform.position+transform.right *10f , Color.red);
    }
    

   
    }
}
