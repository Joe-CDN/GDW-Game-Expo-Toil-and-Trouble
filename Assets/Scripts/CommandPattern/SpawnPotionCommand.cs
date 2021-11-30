using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPotionCommand : ICommand
{
    Vector3 position;
    Transform potion;
    public SpawnPotionCommand(Vector3 position, Transform potion)
    {
        this.position = position;
        this.potion = potion;
    }
    
    public void Execute()
    {
        PotionPlacer.PlacePotion(position, potion);
    }

    public void Undo()
    {
        PotionPlacer.RemovePotion(position);
    }
}
