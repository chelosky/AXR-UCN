using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    private GameObject _foto;
    private bool activo = false;
    // Start is called before the first frame update
    void Start()
    {
        this._foto = this.transform.Find("Foto").gameObject;
        this._foto.SetActive(activo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarmensaje(){
        Debug.Log("PANTALLA");
    }

    public void activarImagen(){
        activo = !activo;
        this._foto.SetActive(activo);
    }

    public void rollingsoza(){
        this._foto.GetComponent<Animator>().SetTrigger("reprobaste");
    }
}
