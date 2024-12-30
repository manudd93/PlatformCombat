using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler
{
   [SerializeField] private Canvas canvas;
   private RectTransform rectTransform;
   private void Awake(){
rectTransform=GetComponent<RectTransform>();
   }
  public void OnPointerDown(PointerEventData eventData) {
      Debug.Log("clicca");
     //throw new System.NotImplementedException();
  }

  
  public void OnEndDrag(PointerEventData eventData) {
      Debug.Log("Smette di trascina");
      
    // throw new System.NotImplementedException();
  }

  
  public void OnBeginDrag(PointerEventData eventData) {
      Debug.Log("inizio trascina");
    // throw new System.NotImplementedException();
  }
   public void OnDrag(PointerEventData eventData) {
      rectTransform.anchoredPosition +=eventData.delta / canvas.scaleFactor;
    // throw new System.NotImplementedException();
  }
}
