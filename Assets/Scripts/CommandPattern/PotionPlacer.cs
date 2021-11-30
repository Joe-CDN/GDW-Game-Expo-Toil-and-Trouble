using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPlacer : MonoBehaviour
{
    static List<Transform> potions;

    public static void PlacePotion(Vector3 position, Transform potion)
    {
        Transform newPot = Instantiate(potion, position, Quaternion.identity);
        if (potions == null){
            potions = new List<Transform>();
        }
        potions.Add(newPot);
    }

    public static void RemovePotion(Vector3 position)
    {
        for (int i = 0; i < potions.Count; i++){
            if (potions[i].position == position) 
            {
                GameObject.Destroy(potions[i].gameObject);
                potions.RemoveAt(i);
                break;
            }
        }
    }
}
