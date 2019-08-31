﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class MenuTreeController : MonoBehaviour
{
    List<Button> childButtons = new List<Button>();
    [SerializeField]List<RectTransform> positionFinalButtons = new List<RectTransform>();
    [SerializeField]List<GameObject> textIcons = new List<GameObject>();

    Vector3[] buttonGoalPos;
    private bool openMenu = false;
    private int buttonDistance = 200;//distancia entre botones
    private float speedAnimation = 3f;
    string[] pathScenes = {"1_EIC","2_STAFF","3_ICCI","4_ICI","5_GALERIA","6_RELLENO","7_RELLENO"};
    
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos todos los hijos del main button
        this.childButtons = this.GetComponentsInChildren<Button>(true).Where(x=> x.gameObject.transform.parent != transform.parent).ToList();
        this.buttonGoalPos = new Vector3[this.childButtons.Count];
        for(int i=0;i<this.childButtons.Count;i++){
            GameObject go = this.childButtons[i].gameObject;
            this.positionFinalButtons.Add(this.transform.Find("Position"+i).GetComponent<RectTransform>());
            this.textIcons.Add(this.transform.Find("Text"+i).gameObject);
            go.transform.position = this.transform.position;
            go.GetComponent<Image>().color = new Color(1,1,1,0);
            go.SetActive(false);
            SubButtonController sbc = this.childButtons[i].GetComponent<SubButtonController>();
            sbc.SetButtonScene(this.pathScenes[i]);
            sbc.SetIdPanel(i);
            this.childButtons[i].interactable = false;
        }
        this.GetComponent<Button>().onClick.AddListener( () => {OpenMenu();});
        this.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
        EnableDisableButton(false);
        StartCoroutine(ResizeImage());
        StartCoroutine(MoveImage());
    }

    private void SetTextsState(bool value){
        for (int i = 0; i< this.textIcons.Count; i++)
        {
            this.textIcons[i].SetActive(value);
        }
    }

    private IEnumerator MoveImage(){
        yield return new WaitForSeconds(0.1f);
        Vector2 originalPos = this.GetComponent<RectTransform>().localPosition;
        Vector2 finalPos = new Vector2(-270,220);
        float durationMove = 1.5f;
        float i=0.0f;
        float speed = 2f;
        float rate = speed/durationMove;
        while(i < 1.0f){
            i+=Time.deltaTime * rate;
            this.GetComponent<RectTransform>().localPosition = Vector2.Lerp(originalPos,finalPos,i);
            yield return null;
        }
        this.ActivePanelBehaviour();
        
    }
    private IEnumerator ResizeImage(){
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Button>().interactable = false;
        float i = 0.0f;
        float speed = 2f;
        float duration = 1.5f;
        float rate = (1.0f / duration) * speed;
        Vector2 finalvect = new Vector2(80,80);
        Vector2 originalvect = this.GetComponent<RectTransform>().sizeDelta;
        while(i < 1.0f){
            i += Time.deltaTime * rate;
            this.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(originalvect,finalvect,i);
            yield return null;
        }
    }

    private void ActivePanelBehaviour(){
        EnableDisableButton(true);
        AppManager.instance.ActivePanelSelected();
    }

    #region openclosemenubehavior
    private void EnableDisableButton(bool value){
        this.GetComponent<Button>().interactable = value;
    }
    public void OpenMenu(){
        this.EnableDisableButton(false);
        float baseAngle = 270 * Mathf.Deg2Rad; //ANGULO BASE (270°)
        this.openMenu = !this.openMenu;
        float offset = 12f;
        float factor = 0.2f;
        for(int i=0;i <= this.childButtons.Count-1;i++){
            if(this.openMenu){
                // float xpos = 0;
                // float ypos = -offset -this.buttonDistance*(i) - this.GetComponent<RectTransform>().sizeDelta.y * factor - this.childButtons[i].GetComponent<RectTransform>().sizeDelta.y * factor;
                // this.buttonGoalPos[i] = new Vector3(this.transform.position.x + xpos,this.transform.position.y + ypos,this.transform.position.z);
                this.buttonGoalPos[i] = this.positionFinalButtons[i].localPosition;
            }else{
                // this.buttonGoalPos[i]= this.transform.position;
                this.buttonGoalPos[i] = new Vector3(0f,0f,0f);
            }
        }
        StartCoroutine(MoveButtons());
    }

    private IEnumerator MoveButtons(){
        if(!this.openMenu){
            this.SetTextsState(false);
        }
        foreach(Button b in this.childButtons){
            b.gameObject.SetActive(true);
            if(!this.openMenu){
                b.interactable = false;
            }
        }
        int loops=0;
        while(loops <= this.buttonDistance/speedAnimation){
            yield return new WaitForSeconds(0.01f);
            for(int i=0; i< this.childButtons.Count;i++){
                Color c = this.childButtons[i].gameObject.GetComponent<Image>().color;
                if(this.openMenu){
                    c.a = Mathf.Lerp(c.a,1,speedAnimation*Time.deltaTime);
                }else{
                    c.a = Mathf.Lerp(c.a,0,speedAnimation*Time.deltaTime);
                }
                this.childButtons[i].gameObject.GetComponent<Image>().color = c;
                // this.childButtons[i].gameObject.transform.position = Vector3.Lerp(this.childButtons[i].gameObject.transform.position,this.buttonGoalPos[i],speedAnimation*Time.deltaTime);
                this.childButtons[i].GetComponent<RectTransform>().localPosition = Vector3.Lerp(this.childButtons[i].gameObject.GetComponent<RectTransform>().localPosition,this.buttonGoalPos[i],speedAnimation*Time.deltaTime);
                this.childButtons[i].GetComponent<RectTransform>().localPosition = new Vector3(this.childButtons[i].GetComponent<RectTransform>().localPosition.x,this.childButtons[i].GetComponent<RectTransform>().localPosition.y,0f);
            }
            loops++;
        }
        if(!this.openMenu){
            foreach (Button b in this.childButtons)
            {
                b.gameObject.SetActive(false);
            }
        }else{
            this.SetTextsState(true);
            foreach (Button b in this.childButtons)
            {
                if(AppManager.instance.Ready){
                    b.interactable = true;
                }
            }
        }
        this.EnableDisableButton(true);
    }
    #endregion

    public void ActDesactAllSubButtons(bool value){
        foreach(Button b in this.childButtons){
            b.interactable = value;
        }
    }
    
}
