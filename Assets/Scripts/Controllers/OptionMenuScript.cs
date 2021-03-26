using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenuScript : MonoBehaviour
{
    [SerializeField] GameObject globalSound, music, fxSound,backButton;
    GlobalMenueScript global;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        global = GameObject.Find("Menu").GetComponent<GlobalMenueScript>();
        //audioController
        music = GameObject.Find("Music");
        music.GetComponentInChildren<Text>().text = "Music";
        //controlador de efectos especiales
        fxSound = GameObject.Find("FX");
        fxSound.GetComponentInChildren<Text>().text = "FX";
        //controlador back button
        backButton = GameObject.Find("BackButton");
        backButton.GetComponentInChildren<Text>().text = "Back";
        backButton.GetComponentInChildren<Button>().onClick.AddListener(() => MainMenuActivation());
    }
    void MainMenuActivation()
    {
        global.optionMenu.SetActive(false);
        global.mainMenu.SetActive(true);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    // Update is called once per frame

}
