using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushPool : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static brushPool Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }

    public GameObject GetFromPool(GameObject prefab){
        if(availableObjects.Count == 0)
            GrowPool(prefab);

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool(GameObject prefab){
        for(int i=0; i<10; i++){
            var instanceToAdd = Instantiate(prefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance){
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
