using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public static AI Instance {get; private set;}
    public GameObject StartPos;
    public GameObject EndPos;
    public GameObject hand;
    public GameObject bubble;

    [SerializeField]    private GameObject bloodPrefab;
    
    //bool approach = true;
    int randPotRequest = 0;
    float potionTotalRequested = 0f;
    //float fraction = 0;
    public float speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        RequestPotion();
        PersistanceManager.instance.npcApproach = true;
        PersistanceManager.instance.npcApproachPercent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //PersistanceManager.instance.npcApproach = approach;
        //PersistanceManager.instance.npcApproachPercent = fraction;
        if(PersistanceManager.instance.npcApproach == true){
            if (PersistanceManager.instance.npcApproachPercent < 1) {
                PersistanceManager.instance.npcApproachPercent += Time.deltaTime * speed;

                Vector3 interpolatedPosition = Vector3.Lerp(StartPos.transform.position, EndPos.transform.position, PersistanceManager.instance.npcApproachPercent);

                this.transform.position = interpolatedPosition;
                if (PersistanceManager.instance.npcApproachPercent >= 1 && potionTotalRequested == 50.61f) {
                    giveDNA();
                }
            }
        }
        if(PersistanceManager.instance.npcApproach == false){
            if (PersistanceManager.instance.npcApproachPercent < 1) {
                PersistanceManager.instance.npcApproachPercent += Time.deltaTime * speed;
                
                this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);    
                
                Vector3 interpolatedPosition = Vector3.Lerp(EndPos.transform.position, StartPos.transform.position, PersistanceManager.instance.npcApproachPercent);

                this.transform.position = interpolatedPosition;

                if (PersistanceManager.instance.npcApproachPercent >= 1) {
                    PersistanceManager.instance.npcApproach = true;
                    RequestPotion();                    
                    this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                    PersistanceManager.instance.npcApproachPercent = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("purePot")){
            if(potionTotalRequested == 27.77f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
            }            
        }
        if (collision.collider.tag.Equals("goldPot")){
            if(potionTotalRequested == 23.26f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
            } 
        }
        if (collision.collider.tag.Equals("sadPot")){
            if(potionTotalRequested == 29.18f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
            }
        }
        if (collision.collider.tag.Equals("lovePot")){
            if(potionTotalRequested == 50.61f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 40;
            }
        }
        if (collision.collider.tag.Equals("catFaePot")){
            if(potionTotalRequested == 30.21f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 30;
            }
        }
        if (collision.collider.tag.Equals("timePot")){
            if(potionTotalRequested == 26.19f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
            }
        }
        if (collision.collider.tag.Equals("truthPot")){
            if(potionTotalRequested == 14.88f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 10;
            }
        }
        if (collision.collider.tag.Equals("happyPot")){
            if(potionTotalRequested == 23.42f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
            }
        }
    }
    void ResetNPC(Collision collision)
    {
        Destroy(collision.gameObject);
        PersistanceManager.instance.npcApproachPercent = 0;
        PersistanceManager.instance.npcApproach = false;            
    }
    void RequestPotion()
    {
        randPotRequest = Random.Range(0, 8);

        if(randPotRequest == 0){
            potionTotalRequested = 27.77f; //purify potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0.6509434f, 0.6349769f, 0.6349769f);
        }
        if(randPotRequest == 1){
            potionTotalRequested = 23.26f; //gold potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 0.8382407f, 0f);
        }
        if(randPotRequest == 2){
            potionTotalRequested = 29.18f; //sad potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0.1437f, 0.01331432f, 0.4150943f);
        }
        if(randPotRequest == 3){
            potionTotalRequested = 50.61f; // love potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 0f, 0.9095554f);
        }
        if(randPotRequest == 4){
            potionTotalRequested = 30.21f; //cat fairy potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0f, 1f, 0.7181935f);
        }
        if(randPotRequest == 5){
            potionTotalRequested = 26.19f; //time potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0f, 0.4150943f, 0.05119479f);
        }
        if(randPotRequest == 6){
            potionTotalRequested = 14.88f; //truth potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0f, 0.5359084f, 1f);
        }
        if(randPotRequest == 7){
            potionTotalRequested = 23.42f; //happy potion
            bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 0.4665077f, 0f);
        }
    }

    void giveDNA()
    {
        SpawnFromPool(bloodPrefab);
    }
    public void SpawnFromPool(GameObject prefab){
        var spawn = dnaPool.Instance.GetFromPool(prefab);
        spawn.transform.position = hand.transform.position;
    }
}
