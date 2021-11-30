using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime; //*
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ().clip = PersistanceManager.instance.dayEndMusic;
        GetComponent<AudioSource> ().playOnAwake = true;        
        GetComponent<AudioSource> ().loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Money Earned: " + PersistanceManager.instance.score + "gp";
    }

    public void toMainMenu()
    {
        StartCoroutine(Disconnect());
        SceneManager.LoadScene("Start");
        GetComponent<AudioSource> ().Stop();
        PersistanceManager.instance.score = 0;
    }
    public void toLobby()
    {
        StartCoroutine(Disconnect());
        SceneManager.LoadScene("Load");
        GetComponent<AudioSource> ().Stop();
        PersistanceManager.instance.score = 0;
    }

    IEnumerator Disconnect()
    {
        PhotonNetwork.Disconnect();
        while(PhotonNetwork.IsConnected)
            yield return null;
    }
}
