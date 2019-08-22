using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoICCI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public void openPanel(){
        if(Panel1 != null && Panel2!=null &&Panel3!=null)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
        }
    }

   
     public void openPanel3(){
         if(Panel1 != null && Panel2!=null &&Panel3!=null)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
        }
        
    }
    public void openPanel2(){
         if(Panel1 != null && Panel2!=null &&Panel3!=null)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
        }
    }
    void Start()
    {
     Panel1.SetActive(true);
     Panel2.SetActive(false);
     Panel3.SetActive(false);

    }

  
}
