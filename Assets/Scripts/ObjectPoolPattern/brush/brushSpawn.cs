using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static brushSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = brushPool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
