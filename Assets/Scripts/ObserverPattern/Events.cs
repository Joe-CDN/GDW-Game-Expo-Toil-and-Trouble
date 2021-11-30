using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObserverPattern
{
    //Events
    public abstract class Events
    {
        public abstract void eventTrigger();
    }

    public class DayEnded : Events
    {
        public override  void eventTrigger()
        {
            SceneManager.LoadScene("DayEnd");
        }
    }
    public class NPCLeave : Events
    {
        public override  void eventTrigger()
        {
            PersistanceManager.instance.npcApproachPercent = 0;
            PersistanceManager.instance.npcApproach = false; 
            PersistanceManager.instance.countDown += 60;
        }
    }
}
