using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubuttondialog : MonoBehaviour
{
    public MenuControl _MN;
    public void ActivateButton(){
        _MN.ACTIVEBUTTON();
    }

    public void LoadNextScene(){
        _MN.loadNextSceneFinal();
    }
}
