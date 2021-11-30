using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class book : MonoBehaviour
{
    public RawImage page;

    bool lookedAt;
    // Start is called before the first frame update
    void Start()
    {
        lookedAt = false;
        //page.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, GameObject.Find("recipeBook").transform.position) <= 2f && Input.GetKeyDown(KeyCode.E)){
            lookedAt = !lookedAt; 
        }
        if(Vector3.Distance(this.transform.position, GameObject.Find("recipeBook").transform.position) > 2f){
            lookedAt = false;
        }
        page.gameObject.SetActive(lookedAt);
    }
}
