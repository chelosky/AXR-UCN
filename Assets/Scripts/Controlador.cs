using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diapositiva {
    public string titulo;
    public Sprite fotografia;
    public string descripcion;

    public float tiempo;

    // constructor
    public Diapositiva(string _titulo, string _fotografia, string _descripcion){
        titulo = _titulo;
        fotografia = Resources.Load <Sprite> (_fotografia);
        descripcion = _descripcion;
    }

    
}
public class Controlador : MonoBehaviour
{
    public Text Titulo;
    public Image Fotografia;
    public Text Descripcion;

    public List <Diapositiva> Diapositivas = new List <Diapositiva>();

    public int actual = 0;
    //public float tiempo = 3f;
    void Start()
    {
        Diapositivas.Add(new Diapositiva("Academia de Integración Tecnológica","academias/academia-acadit-eic","La academia de integración tecnológica (AcadIT) tiene como misión el desarrollar actividades teóricas y prácticas para enseñar a los Estudiantes de la Escuela de Ingeniería las siguientes temáticas en el campo de las Tecnologías de la Información: Gestión TI, Networking, Cloud Computing, IoT, Seguridad y Hardware."));
        Diapositivas.Add(new Diapositiva("Academia Robótica AcroEI","academias/academia-robotica","La Academia de Robótica AcroEI tiene como misión la difusión de la robótica como ciencia disponible desde los niveles básicos de la formación de los ingenieros de la UCN y como medio de difusión de la Escuela de Ingeniería para la captación de futuros ingenieros."));
        Diapositivas.Add(new Diapositiva("Academia de Coaching","academias/acdemia-coaching","La Academia de Coaching se define como un espacio de aprendizaje empírico y vivencial, focalizado en el fortalecimiento de las competencias del ser, las que complementadas con los talentos cognitivos propios de los participantes, cimientan el éxito personal y profesional."));
        Diapositivas.Add(new Diapositiva("Academia Operational Intelligence","academias/academia-OI-eic","La academia de Operational Intelligence tiene por objetivo formar estudiantes especialistas que diseñaran e implementaran soluciones de Inteligencia Operacional, aplicando metodologías y mejores prácticas usadas en la industria"));

        Titulo.text = Diapositivas[actual].titulo;
        Fotografia.sprite = Diapositivas[actual].fotografia;   
        Descripcion.text = Diapositivas[actual].descripcion; 
        //CargarImagen ();
    }

     public void siguiente(){
        if (actual >= Diapositivas.Count - 1) actual = 0;
        else actual ++;

        Titulo.text = Diapositivas[actual].titulo;
        Fotografia.sprite = Diapositivas[actual].fotografia;
        Descripcion.text = Diapositivas[actual].descripcion; 

    }

    public void anterior(){
        if (actual <= 0) actual = Diapositivas.Count - 1;
        else actual--;

        Titulo.text = Diapositivas[actual].titulo;
        Fotografia.sprite = Diapositivas[actual].fotografia;
        Descripcion.text = Diapositivas[actual].descripcion; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /* void CargarImagen(){
        Titulo.text = Diapositivas[actual].titulo;
        Fotografia.sprite = Diapositivas[actual].fotografia;
        actual++;
        if (actual >= Diapositivas.Count){
            actual = 0;
        }
        Invoke ("CargarImagen", tiempo);
    }*/
}
