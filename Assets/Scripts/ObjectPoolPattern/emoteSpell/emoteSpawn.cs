using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emoteSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static emoteSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        SpawnFromPool(Prefab);
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = emotePool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
