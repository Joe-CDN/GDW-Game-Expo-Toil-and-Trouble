using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer 
    {
        public abstract void OnNotify();
    }

    public class Clock : Observer
    {
        //What will happen when this observer gets an event
        DayEnded dayOver;

        public Clock(DayEnded dayEvent)
        {
            dayOver = dayEvent;
        }
        public override void OnNotify()
        {
            dayOver.eventTrigger();
        }
    }

    public class NPC : Observer
    {
        NPCLeave npcLeaves;

        public NPC(NPCLeave npsGo)
        {
            npcLeaves = npsGo;
        }
        public override void OnNotify()
        {
            npcLeaves.eventTrigger();
        }
    }
}
