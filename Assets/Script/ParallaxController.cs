using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float Distance;
    GameObject[] Background;
    Material[] mat;
    float[] backSpeed;
    float fartHestBack;
    [Range(0.1f,0.010f)]
    public float parallaxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main.transform;
        camStartPos=cam.position;

        int backCount=transform.childCount;

        mat=new Material[backCount];
        backSpeed=new float[backCount];
        Background=new GameObject[backCount];

        for(int i =0;i<backCount;i++){
            Background[i]=transform.GetChild(i).gameObject;
            mat[i]=Background[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculate(backCount);
    }
void BackSpeedCalculate(int backCount){
    for(int i =0;i<backCount;i++){
        if((Background[i].transform.position.z-cam.position.z)> fartHestBack){
            fartHestBack=Background[i].transform.position.z - cam.position.z;
        }
    }

    for(int i=0;i<backCount;i++){
        backSpeed[i]=1-(Background[i].transform.position.z - cam.position.z) / fartHestBack;
    }
}

    // Update is called once per frame
     void LateUpdate() {
        Distance=cam.position.x -camStartPos.x;
        transform.position=new Vector3(cam.position.x,cam.position.y,0);
        for(int i=0;i<Background.Length;i++){
            float speed=backSpeed[i]*parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex",new Vector2(Distance,0)*speed);
        }
    }
}
