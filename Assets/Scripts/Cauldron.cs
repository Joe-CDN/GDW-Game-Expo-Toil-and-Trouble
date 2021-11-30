using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public static float potionTotal;

    [SerializeField]    private GameObject brushPrefab;
    [SerializeField]    private GameObject waterPrefab;
    [SerializeField]    private GameObject sugarPrefab;
    [SerializeField]    private GameObject spicePrefab;
    [SerializeField]    private GameObject goldPrefab;
    [SerializeField]    private GameObject fishPrefab;
    [SerializeField]    private GameObject catnipPrefab;
    [SerializeField]    private GameObject fluffPrefab;
    [SerializeField]    private GameObject clockPrefab;
    [SerializeField]    private GameObject DNAPrefab;
    [SerializeField]    private GameObject rosePrefab;
    [SerializeField]    private GameObject morphPrefab;
    [SerializeField]    private GameObject emotePrefab;

    void Start()
    {
        potionTotal = 0;
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = PersistanceManager.instance.dropInCauldron;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("brush"))
        {
            potionTotal = 0f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            brushSpawn.Instance.SpawnFromPool(brushPrefab);
        }
        if (collision.collider.tag.Equals("water"))
        {
            potionTotal += 6.71f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            bucketSpawn.Instance.SpawnFromPool(waterPrefab);
        }
        if (collision.collider.tag.Equals("sugar"))
        {
            potionTotal += 8.59f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            sugarSpawn.Instance.SpawnFromPool(sugarPrefab);
        }
        if (collision.collider.tag.Equals("spice"))
        {
            potionTotal += 9.1f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            spiceSpawn.Instance.SpawnFromPool(spicePrefab);
        }
        if (collision.collider.tag.Equals("gold"))
        {
            potionTotal += 4.08f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            goldSpawn.Instance.SpawnFromPool(goldPrefab);
        }
        if (collision.collider.tag.Equals("fish"))
        {
            potionTotal += 1.17f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            fishSpawn.Instance.SpawnFromPool(fishPrefab);
        }
        if (collision.collider.tag.Equals("catnip"))
        {
            potionTotal += 2.41f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            catnipSpawn.Instance.SpawnFromPool(catnipPrefab);
        }
        if (collision.collider.tag.Equals("fluff"))
        {
            potionTotal += 3.34f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            fluffSpawn.Instance.SpawnFromPool(fluffPrefab);
        }
        if (collision.collider.tag.Equals("clock"))
        {
            potionTotal += 5.13f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            clockSpawn.Instance.SpawnFromPool(clockPrefab);
        }
        if (collision.collider.tag.Equals("DNA"))
        {
            potionTotal += 7.27f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();            
        }
        if (collision.collider.tag.Equals("rose"))
        {
            potionTotal += 10.82f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            roseSpawn.Instance.SpawnFromPool(rosePrefab);
        }
        if (collision.collider.tag.Equals("morphSpell"))
        {
            potionTotal += 12.47f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            morphSpawn.Instance.SpawnFromPool(morphPrefab);
        }
        if (collision.collider.tag.Equals("emoteSpell"))
        {
            potionTotal += 11.49f;
            Debug.Log(potionTotal);
            GetComponent<AudioSource> ().Play ();
            emoteSpawn.Instance.SpawnFromPool(emotePrefab);
        }  
    }
}
