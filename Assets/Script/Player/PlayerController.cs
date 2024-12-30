using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TrasformationManager trasformationManager;
    // Start is called before the first frame update
    void Start()
    {
        trasformationManager = GetComponent<TrasformationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            trasformationManager.StartTrasformation();
        }
    }
}
