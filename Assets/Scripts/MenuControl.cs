using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    private GameObject _foto;
    private bool activoMesaje = false;
    public GameObject infoMensaje;
    public GameObject buttonDialog;
    // Start is called before the first frame update
    void Start()
    {
        // this._foto = this.transform.Find("Foto").gameObject;
        // this._foto.SetActive(activo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDialog(){
        this.infoMensaje.SetActive(true);
        this.infoMensaje.GetComponent<Animator>().SetTrigger("startanim");
    }

    public void ACTIVEBUTTON(){
        this.buttonDialog.SetActive(true);
    }

    public void closeDialog(){
        this.infoMensaje.GetComponent<Animator>().SetTrigger("backtonormal");
        this.buttonDialog.SetActive(false);
    }

    public void loadSceneFinal(){
          SceneManager.LoadScene("MainScene");
    }

    public void closeApp(){
        Application.Quit();
    }
}
