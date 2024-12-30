using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackFeedBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RB;

    [SerializeField]
    private float strengt=10f,delay=2f;
    

    public UnityEvent OnBegin,OnDone;
    // Start is called before the first frame update
   private IEnumerator Reset(float Delay){
    
    yield return new WaitForSeconds(Delay);
    RB.velocity=Vector3.zero;
    OnDone?.Invoke();
   }

   public void PlayFeedBack(GameObject sender,float Force,float duration){
    StopAllCoroutines();
    OnBegin?.Invoke();
    Vector2 direction=(transform.position-sender.transform.position).normalized;
    RB.AddForce(direction*Force,ForceMode2D.Impulse);

    StartCoroutine(Reset(duration));
   }
   public void PlayKnockUp(GameObject sender,bool flipped,float Force,float duration){
    StopAllCoroutines();
    OnBegin?.Invoke();
    Vector2 direction=(transform.position-sender.transform.position).normalized;
    Debug.Log(direction);
  // direction.x-=1;
    //direction.y-=2;
    if(flipped){
    
         RB.AddForce(new Vector2(direction.x-1,direction.y+2)*Force,ForceMode2D.Impulse); 
    }else{
   RB.AddForce(new Vector2(direction.x+1,direction.y+2)*Force,ForceMode2D.Impulse);
    }
     
 
    StartCoroutine(Reset(duration));
   }
}
