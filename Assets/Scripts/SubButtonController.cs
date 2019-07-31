using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubButtonController : MonoBehaviour
{
    private string sceneButton;
    private int idPanel;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener( () => {LoadButtonScene();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIdPanel(int idx){
        this.idPanel = idx;
    }

    public void SetButtonScene(string scenename){
        this.sceneButton = scenename;
    }

    public void LoadButtonScene(){
        AppManager.instance.PanelSelected(this.idPanel); 
    }
}
