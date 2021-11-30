using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morphSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static morphSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = morphPool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
