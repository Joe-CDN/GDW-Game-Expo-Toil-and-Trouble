using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        //Will send notifications that something has happened to whoever is interested
        public int timeDayEnds;
        Subject subject = new Subject();

        Subject subject2 = new Subject();

        // Start is called before the first frame update
        void Start()
        {
            Clock dayClock = new Clock(new DayEnded());
            subject.AddObserver(dayClock);

            NPC customer = new NPC(new NPCLeave());
            subject2.AddObserver(customer);
        }

        // Update is called once per frame
        void Update()
        {
            if(PersistanceManager.instance.timeOfDay == timeDayEnds)
            {
                subject.Notify();
            }
            if(PersistanceManager.instance.countDown <= 0)
            {
                subject2.Notify();
            }
        }
    }
}
