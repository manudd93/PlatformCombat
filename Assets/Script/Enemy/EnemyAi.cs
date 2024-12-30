using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class EnemyAi : MonoBehaviour
{
   private Vector3 startingPosition;

   private void Start(){
       startingPosition=transform.position;
   }


   private Vector3 GetRoamingPosition(){
return startingPosition + UtilsClass.GetRandomDir()*Random.Range(10f,70f);
   }
}
