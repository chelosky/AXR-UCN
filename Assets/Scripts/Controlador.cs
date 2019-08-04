using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diapositiva {
    public string titulo;
    public Sprite fotografia;

    // constructor
    public Diapositiva(string _titulo, string _fotografia){
        titulo = _titulo;
        fotografia = Resources.Load <Sprite> (_fotografia);
    }

    
}
public class Controlador : MonoBehaviour
{
    public Text Titulo;
    public Image Fotografia;

    public List <Diapositiva> Diapositivas = new List <Diapositiva>();

    public int actual = 0;
    public float tiempo = 3f;
    void Start()
    {
        Diapositivas.Add(new Diapositiva("Academia de Integración Tecnológica","academias/academia-acadit-eic"));
        Diapositivas.Add(new Diapositiva("Academia Robótica AcroEI","academias/academia-robotica"));
        Diapositivas.Add(new Diapositiva("Academia de Coaching","academias/acdemia-coaching"));
        Diapositivas.Add(new Diapositiva("Academia Operational Intelligence","academias/academia-OI-eic"));

        
        CargarImagen ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CargarImagen(){
        Titulo.text = Diapositivas[actual].titulo;
        Fotografia.sprite = Diapositivas[actual].fotografia;
        actual++;
        if (actual >= Diapositivas.Count){
            actual = 0;
        }
        Invoke ("CargarImagen", tiempo);
    }
}
