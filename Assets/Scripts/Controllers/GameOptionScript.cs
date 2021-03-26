using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameOptionScript : MonoBehaviour
{
    [SerializeField] GameObject  music, fxSound, backButton;
    Canvas options;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        //audioController
        music = GameObject.Find("Music");
        music.GetComponentInChildren<Text>().text = "Music";
        //controlador de efectos especiales
        fxSound = GameObject.Find("FX");
        fxSound.GetComponentInChildren<Text>().text = "FX";
        //controlador back button
        backButton = GameObject.Find("BackButton");
        backButton.GetComponentInChildren<Text>().text = "Back";
        backButton.GetComponentInChildren<Button>().onClick.AddListener(() => GoBack());
    }
    void GoBack()
    {
        Time.timeScale = 1;
        options = this.gameObject.GetComponent<Canvas>();
        options.enabled = false;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    // Update is called once per frame

}

