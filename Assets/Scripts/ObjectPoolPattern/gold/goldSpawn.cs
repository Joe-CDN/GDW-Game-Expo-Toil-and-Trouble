using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static goldSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = goldPool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
