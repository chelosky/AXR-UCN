using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class CardListBehaviour : MonoBehaviour
{
    public List<GameObject> cards;
    // Start is called before the first frame update
    void Start()
    {
        int children = this.transform.childCount;
        for (int i = 0; i < children; ++i){
            cards.Add(this.transform.GetChild(i).gameObject);
        }
        StartCoroutine(this.StartAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartAnimation(){
        yield return new WaitForSeconds(0.3f);
        for(int i=0;i<this.cards.Count;i++){
            this.cards[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ResetList(){
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x,-512);
    }
}
