using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MallaZoomControl : MonoBehaviour, IPointerClickHandler , IBeginDragHandler, IEndDragHandler   
{
    private Vector2 finalDimension = new Vector2(1800f,1260f);
    private Vector2 initialDimension;
    private bool stateSize = false;
    private bool isDraged = false;

    public void Start(){
        this.initialDimension = this.transform.GetComponent<RectTransform>().sizeDelta;
    }


    public void IncreaseSizeImage(){
        if(this.stateSize == false){
            this.transform.GetComponent<RectTransform>().sizeDelta = finalDimension;
        }else{
            this.transform.GetComponent<RectTransform>().sizeDelta = initialDimension;
        }
        this.stateSize = !this.stateSize;
    }

    public void OnPointerClick (PointerEventData eventData) 
	{
		if(eventData.clickCount >= 1 && this.isDraged == false){
            this.IncreaseSizeImage();
        }
	}

    public void OnBeginDrag(PointerEventData eventData){
        this.isDraged = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.isDraged = false;
    }
    // private IEnumerator AnimationSize(){
        
    // }
}
