using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager instance { get; private set; }

    public AudioClip dropInCauldron;
    public AudioClip titleMusic;
    public AudioClip dayEndMusic;

    public int score;

    public int timeOfDay;

    public float countDown;
    public float npcApproachPercent;

    public bool useJoystick = false;
    public bool grabObject = false;
    public bool playing = false;    
    public bool npcApproach;    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
