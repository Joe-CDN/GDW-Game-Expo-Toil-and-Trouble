using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDNACommand : ICommand
{
    Vector3 position;
    Transform sample;
    public SpawnDNACommand(Vector3 position, Transform sample)
    {
        this.position = position;
        this.sample = sample;
    }
    
    public void Execute()
    {
        PotionPlacer.PlacePotion(position, sample);
    }

    public void Undo()
    {
        PotionPlacer.RemovePotion(position);
    }
}
