using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAttack : MonoBehaviour
{

    public GameObject Chain;
    public Vector2 RangeMax;
    public Transform AttackPoint;
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector2 LookDir;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       mousePos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExecuteAttack();

        }
    }


    void ExecuteAttack()
    {
        
         LookDir =  mousePos-AttackPoint.localPosition;
        
        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;
        
            AttackPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle +90);
        
       

        GameObject ChainInst = Instantiate(Chain, AttackPoint.transform.position, AttackPoint.rotation);

    }
}
