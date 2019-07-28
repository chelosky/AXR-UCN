using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public enum PerformUser{
		WAIT, //USER HAS TO WAIT THE ANIMATIONS ARE DONE TO USE THE GUI.
		CANPLAY//USER CAN USE THE UI FREELY
	}

    public enum PerformAnimation{
        STARTING,//ANIMATION START -> IMPLIES THE USER CAN'T USE THE GUI
		WAITING,//ANIMATION IS WAITING FOR I/O OF USER
		PROCESSING,//ANIMATION IS IN PROGRESS
		DONE//ANIMATION HAVE ENDED, SO THE USER CAN USE DE GUI AGAIN
    }

    public PerformAnimation animationInput;
    public PerformUser userInput;

    public static AppManager instance { get ; private set;} 
    
    //SINGLETON
    void Awake(){
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.animationInput = PerformAnimation.WAITING;
        this.userInput = PerformUser.CANPLAY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestSingleton(){
        Debug.Log("TEST");
    }
    
}
