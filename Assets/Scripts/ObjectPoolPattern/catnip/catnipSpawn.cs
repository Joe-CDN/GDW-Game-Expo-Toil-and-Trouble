using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catnipSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static catnipSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = catnipPool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
