using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
      public List<AudioClip> FootStepClip;
    public AudioSource audioSource;
   private void Start() {
    audioSource=GetComponent<AudioSource>();
   }
public void PlayFootStep(){
//    int n=Random.Range(1,FootStepClip.Count);
audioSource.clip=FootStepClip[0];
  audioSource.PlayOneShot(audioSource.clip);
//FootStepClip[n]=FootStepClip[0];
// FootStepClip[0]=audioSource.clip;

}
    public void StopSound()
    {
        audioSource.Stop();
    }

    
}
