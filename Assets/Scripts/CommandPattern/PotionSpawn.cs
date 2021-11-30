using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawn : MonoBehaviour
{
    public Transform purePotPrefab;
    public Transform goldPotPrefab;
    public Transform sadPotPrefab;
    public Transform lovePotPrefab;
    public Transform catFaePotPrefab;
    public Transform happyPotPrefab;
    public Transform timePotPrefab;
    public Transform truthPotPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Cauldron.potionTotal == 27.77f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, purePotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 23.26f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, goldPotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 29.18f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, sadPotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 50.61f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, lovePotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 30.21f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, catFaePotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 26.19f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, timePotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 14.88f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, truthPotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
        if(Cauldron.potionTotal == 23.42f)
        {
            ICommand command = new SpawnPotionCommand(this.transform.position, happyPotPrefab);
            CommandInvoker.AddCopmmand(command);
            Cauldron.potionTotal = 0;
        }
    }
}
