using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static clockSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = clockPool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
