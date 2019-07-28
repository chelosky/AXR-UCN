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
    private float intialAngle = 150 * Mathf.Deg2Rad; //ANGULO INICIAL (150°)
    private float angleDistance = 50 * Mathf.Deg2Rad; //DISTANCIA ENTRE SUBBOTONES
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
            this.childButtons[i].gameObject.transform.position = this.transform.position;
            this.childButtons[i].gameObject.GetComponent<Image>().color = new Color(1,1,1,0);
            this.childButtons[i].gameObject.SetActive(false);
            this.childButtons[i].GetComponent<SubButtonController>().SetButtonScene(this.pathScenes[i]);
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

    private void EnableDisableButton(){
        this.GetComponent<Button>().interactable = !this.GetComponent<Button>().interactable;
    }
    public void OpenMenu(){
        this.EnableDisableButton();
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
        }
        this.EnableDisableButton();
    }
}
