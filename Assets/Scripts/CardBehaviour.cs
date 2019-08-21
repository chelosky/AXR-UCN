using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardBehaviour : MonoBehaviour
{
    public AcademicosModel academicModel; 
    private Animator m_Animator;
    private List<GameObject> listButtonsLinks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if(this.academicModel != null){
            // Debug.Log(this.transform.childCount);
            // this.transform.GetChild(1).GetComponent<Image>().sprite = academicModel.fotoPerfil;
            this.transform.Find("Elements").Find("Image").GetComponent<Image>().sprite = academicModel.fotoPerfil;
            this.transform.Find("Elements").Find("Nombre").GetComponent<TMPro.TextMeshProUGUI>().text = academicModel.name;
            this.transform.Find("Elements").Find("Grado").GetComponent<TMPro.TextMeshProUGUI>().text = academicModel.grado;
            this.transform.Find("Elements").Find("Email").GetComponent<TMPro.TextMeshProUGUI>().text = academicModel.email;
        }
        m_Animator = gameObject.GetComponent<Animator>();
        this.GetComponent<Button>().onClick.AddListener( () => {TriggerPressed();});
        listButtonsLinks.Add(this.transform.Find("GS").gameObject);
        listButtonsLinks.Add(this.transform.Find("External").gameObject);
        listButtonsLinks.Add(this.transform.Find("RG").gameObject);
        this.transform.Find("BACK").GetComponent<Button>().onClick.AddListener( () => {TriggerPressedAgain();});
        listButtonsLinks.Add(this.transform.Find("BACK").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerPressed(){
        StartCoroutine(this.TriggerButton());
    }

    private IEnumerator TriggerButton(){
        m_Animator.SetTrigger("Pressed");
        m_Animator.SetBool("Animating",true);
        yield return new WaitForSeconds(0.5f);
        m_Animator.ResetTrigger("Pressed");
        for(int i=0;i<this.listButtonsLinks.Count;i++){
            this.listButtonsLinks[i].GetComponent<Animator>().SetTrigger("FadeIn");
        }
        yield return new WaitForSeconds(0.5f);
    }

    public void TriggerPressedAgain(){
        StartCoroutine(this.BackToNormal());
    }

    private IEnumerator BackToNormal(){
        m_Animator.SetBool("Animating",true);
        for(int i=0;i<this.listButtonsLinks.Count;i++){
            this.listButtonsLinks[i].GetComponent<Animator>().SetTrigger("FadeOut");
        }  
        yield return new WaitForSeconds(0.2f);
        m_Animator.SetBool("Animating",false);

    }
}

