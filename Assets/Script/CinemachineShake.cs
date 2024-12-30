using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public static CinemachineShake Instance{get;private set;}
    private float shakeTimer;
    // Start is called before the first frame update
   private void Awake() {
    Instance = this;
  cinemachineVirtualCamera= GetComponent<CinemachineVirtualCamera>();
   }
   public void ShakeCamera(float intensity,float timer){
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin= cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain=intensity;

    shakeTimer=timer;



   }

    private void Update() {
        if(shakeTimer>0){
 shakeTimer -=Time.deltaTime;
 if(shakeTimer <=0f){
       CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin= cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain=0;
 }
        }
   

   }
   }
