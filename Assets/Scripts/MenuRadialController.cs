using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuRadialController : MonoBehaviour
{
    List<Button> childButtons = new List<Button>();
    Vector2[] buttonGoalPos;
    private bool openMenu = false;
    private float intialAngle = 90 * Mathf.Deg2Rad; //ANGULO INICIAL (150°)
    private float angleDistance = 60 * Mathf.Deg2Rad; //DISTANCIA ENTRE SUBBOTONES
    private int buttonDistance = 200;//radio
    private float speedAnimation = 4f;
    string[] pathScenes = {"1_EIC","2_STAFF","3_ICCI","4_ICI","5_GALERIA","6_RELLENO","7_RELLENO"};

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos todos los hijos del main button
        this.childButtons = this.GetComponentsInChildren<Button>(true).Where(x=> x.gameObject.transform.parent != transform.parent).ToList();
        this.buttonGoalPos = new Vector2[this.childButtons.Count];
        for(int i=0;i<this.childButtons.Count;i++){
            GameObject go = this.childButtons[i].gameObject;
            go.transform.position = this.transform.position;
            go.GetComponent<Image>().color = new Color(1,1,1,0);
            go.SetActive(false);
            SubButtonController sbc = this.childButtons[i].GetComponent<SubButtonController>();
            sbc.SetButtonScene(this.pathScenes[i]);
            sbc.SetIdPanel(i);
            this.childButtons[i].interactable = false;
        }
        // foreach (Button b in this.childButtons)
        // {
        //     b.gameObject.transform.position = this.transform.position;
        //     b.gameObject.GetComponent<Image>().color = new Color(1,1,1,0);
        //     b.gameObject.SetActive(false);
        // }
        this.GetComponent<Button>().onClick.AddListener( () => {OpenMenu();});
        this.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f); 
    }

    private void EnableDisableButton(bool value){
        this.GetComponent<Button>().interactable = value;
    }

    public void OpenMenu(){
        this.EnableDisableButton(false);
        this.openMenu = !this.openMenu;
        for(int i=0;i <= this.childButtons.Count-1;i++){
            if(this.openMenu){
                float xpos = Mathf.Cos(this.intialAngle + this.angleDistance*i) * this.buttonDistance;
                float ypos = Mathf.Sin(this.intialAngle + this.angleDistance*i) * this.buttonDistance;
                this.buttonGoalPos[i] = new Vector2(this.transform.position.x + xpos,this.transform.position.y + ypos);
            }else{
                this.buttonGoalPos[i]= this.transform.position;
            }
        }
        StartCoroutine(MoveButtons());
    }

    private IEnumerator MoveButtons(){
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
                    c.a = Mathf.Lerp(c.a,0,speedAnimation   *Time.deltaTime);
                }
                this.childButtons[i].gameObject.GetComponent<Image>().color = c;
                this.childButtons[i].gameObject.transform.position = Vector2.Lerp(this.childButtons[i].gameObject.transform.position,this.buttonGoalPos[i],speedAnimation*Time.deltaTime);
            }
            loops++;
        }
        if(!this.openMenu){
            foreach (Button b in this.childButtons)
            {
                b.gameObject.SetActive(false);
            }
        }else{
            foreach (Button b in this.childButtons)
            {
                b.interactable = true;
            }
        }
        this.EnableDisableButton(true);
    }

    public void StartEndAnimation(){
        StartCoroutine(EndAnimation());
    }

    private IEnumerator EndAnimation(){
        this.DisableAllButtons();
        yield return new WaitForSeconds(0.05f);
        int loops=0;
        while(loops <= this.buttonDistance/speedAnimation){
            yield return new WaitForSeconds(0.01f);
            for(int i=0; i< this.childButtons.Count;i++){
                Color c = this.childButtons[i].gameObject.GetComponent<Image>().color;
                c.a = Mathf.Lerp(c.a,0,speedAnimation*1.5f*Time.deltaTime);
                this.childButtons[i].gameObject.GetComponent<Image>().color = c;
                this.childButtons[i].gameObject.transform.position = Vector2.Lerp(this.childButtons[i].gameObject.transform.position,this.transform.position,speedAnimation*1.5f*Time.deltaTime);
            }
            loops++;
        }
        foreach (Button b in this.childButtons)
        {
            b.gameObject.SetActive(false);
        }
        AppManager.instance.StartTransitionMenus();
    }
    
    private void DisableAllButtons(){
        this.EnableDisableButton(false);
        foreach(Button b in this.childButtons){
            b.interactable = false;
        }
    }
}
