using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = true;
        GetComponent<AudioSource> ().clip = PersistanceManager.instance.titleMusic;
        GetComponent<AudioSource> ().loop = true;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Load");
        //GetComponent<AudioSource> ().Stop();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
