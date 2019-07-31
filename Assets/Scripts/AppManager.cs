using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AppManager : MonoBehaviour
{

    public static AppManager instance { get ; private set;} 
    public List<GameObject> panelList;
    public GameObject mainMenuRadial;
    public GameObject mainMenuTree;
    private GameObject panelActual = null;
    private GameObject panelSelected;
    private int idPanelActual = -1;
    private int idPanelSelected;

    public bool Ready = false;
    
    //SINGLETON
    void Awake(){
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.mainMenuRadial.gameObject.SetActive(true);
        this.mainMenuTree.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishAnimMMR(){
        
    }
    
    public void StartTransitionMenus(){
        this.mainMenuTree.gameObject.SetActive(true);
        this.mainMenuRadial.gameObject.SetActive(false);
    }

    public void PanelSelected(int idx){
        if(this.idPanelActual != idx){
            this.panelSelected = this.panelList[idx];
            this.idPanelSelected = idx;
            if(this.mainMenuRadial.gameObject.activeSelf){
                this.mainMenuRadial.GetComponent<MenuRadialController>().StartEndAnimation();
            }else{
                //to do
                this.mainMenuTree.GetComponent<MenuTreeController>().ActDesactAllSubButtons(false);
                this.ActivePanelSelected();
            }
        }
    }

    public void ActivePanelSelected(){
        if(this.idPanelActual == -1|| this.panelActual == null){
            //no hay nada mostrandose, y por tanto es la primera vez que se muestra algo
            //CAMBIAR SELECT -> ACTUAL AND SHOW 
            this.UpdatePanelSelToAct();
        }else{
            //HAY ALGUN PANEL MOSTRANDOSE
            //EJECUTAR ANIMACION DE TERMINAR AL PANEL ACTUAL
            this.panelActual.GetComponent<PanelAnimation>().ClosePanel();
        }
    }

    public void ActiveButtons(){
        this.mainMenuTree.GetComponent<MenuTreeController>().ActDesactAllSubButtons(true);
    }

    public void UpdatePanelSelToAct(){
            this.panelActual = this.panelSelected;
            this.idPanelActual = this.idPanelSelected;
            this.panelSelected = null;
            this.idPanelSelected = -1;
            this.panelActual.gameObject.SetActive(true);
            if(this.panelActual.GetComponent<PanelAnimation>().firstTime == false){
                this.panelActual.GetComponent<PanelAnimation>().OpenPanel();
            }
    }
    
}
