using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeatl : MonoBehaviour
{
    PlayerHealtSystem playerhealt;
     public float firerate=1.1f;
     float nextfire=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerhealt=GameObject.FindObjectOfType<PlayerHealtSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.G) && Time.time>nextfire){
playerhealt.TakeDamage(10);
 nextfire=Time.time+firerate;
        }
    }
}
