using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        AudioSource audio1 = GetComponent<AudioSource>();
        audio1.clip = sound;
        audio1.Play();
        */
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
