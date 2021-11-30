using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugarSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static sugarSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = sugarPool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
