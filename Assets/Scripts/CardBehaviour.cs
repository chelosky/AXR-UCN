using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardBehaviour : MonoBehaviour
{
    public AcademicosModel academicModel; 
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        if(this.academicModel != null){
            // Debug.Log(this.transform.childCount);
            // this.transform.GetChild(1).GetComponent<Image>().sprite = academicModel.fotoPerfil;
            this.transform.Find("Image").GetComponent<Image>().sprite = academicModel.fotoPerfil;
            this.transform.Find("Nombre").GetComponent<TMPro.TextMeshProUGUI>().text = academicModel.name;
            this.transform.Find("Grado").GetComponent<TMPro.TextMeshProUGUI>().text = academicModel.grado;
            this.transform.Find("Email").GetComponent<TMPro.TextMeshProUGUI>().text = academicModel.email;
        }
        m_Animator = gameObject.GetComponent<Animator>();
        this.GetComponent<Button>().onClick.AddListener( () => {TriggerPressed();});
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
        yield return new WaitForSeconds(0.2f);
        m_Animator.ResetTrigger("Pressed");
    }
}
