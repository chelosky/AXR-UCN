using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubButtonController : MonoBehaviour
{
    private string sceneButton;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener( () => {LoadButtonScene();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonScene(string scenename){
        this.sceneButton = scenename;
    }

    public void LoadButtonScene(){
        if( this.sceneButton != null){
            Debug.Log("sceneName to load: " + this.sceneButton);
            //AppManager.instance.TestSingleton();
            // SceneManager.LoadScene(this.sceneButton); 
        }else{
            Debug.Log("ERROR IN " + this.gameObject.name);
        }
    }
}
