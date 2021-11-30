using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawn : MonoBehaviour
{
    [SerializeField]
    private float delay = 1f;

    [SerializeField]    private GameObject Prefab;

    private float lastTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastTime > delay){
            SpawnFromPool(Prefab);
        }
    }

    private void SpawnFromPool(GameObject prefab){
        lastTime = Time.time;

        var item = BasicPool.Instance.GetFromPool(prefab);
        item.transform.position = this.transform.position;
    }
}
