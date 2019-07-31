using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    public bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
        this.OpenPanel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator AnimationPanel(Vector2 initialDim, Vector2 middleDim, Vector2 finalDim, float speedFirst, float speedSecond){
        yield return new WaitForSeconds(0.05f);
        float durationMove = 1f;
        float i=0.0f;
        float rate = speedFirst/durationMove;
        float maxTime = 1.0f;
        while(i < maxTime){
            i+=Time.deltaTime * rate;
            this.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(initialDim,middleDim,i);
            yield return null;
        }
        durationMove = 1f;
        i=0.0f;
        rate = speedSecond/durationMove;
        maxTime = 1.0f;
        while(i < maxTime){
            i+=Time.deltaTime * rate;
            this.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(middleDim,finalDim,i);
            yield return null;
        }
        if(AppManager.instance.Ready){
            AppManager.instance.ActiveButtons();
        }else{
            AppManager.instance.UpdatePanelSelToAct();
            this.gameObject.SetActive(false);
        }
    }

    public void OpenPanel(){
        AppManager.instance.Ready = true;
        this.firstTime = false;
        StartCoroutine(AnimationPanel(this.GetComponent<RectTransform>().sizeDelta,new Vector2(550,550),new Vector2(530,530),5f,10f));
    }

    public void ClosePanel(){
        AppManager.instance.Ready = false;
        StartCoroutine(AnimationPanel(this.GetComponent<RectTransform>().sizeDelta,new Vector2(550,550),new Vector2(0,0),10f,5f));
    }
}
