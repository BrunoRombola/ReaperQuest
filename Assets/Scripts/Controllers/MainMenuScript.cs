using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MainMenuScript: MonoBehaviour
{
    [SerializeField]GameObject title;
    [SerializeField]GameObject playButton,optionButton,galleryButton,quitButton;
    GlobalMenueScript global;
    void Awake()
    {
        //global
        global = GameObject.Find("Menu").GetComponent<GlobalMenueScript>();
        //title
        title = GameObject.Find("Title");
        title.GetComponent<Text>().color = Color.white;
        title.GetComponent<Text>().text = "The Reaper Quest";
        title.GetComponent<Text>().fontSize = 28;
        //play
        playButton = GameObject.Find("Play");
        playButton.GetComponentInChildren<Text>().text = "Play";
        playButton.GetComponentInChildren<Button>().onClick.AddListener(() => SceneManager.LoadScene(1));
        //options
        optionButton = GameObject.Find("Option");
        optionButton.GetComponentInChildren<Text>().text = "Options";
        optionButton.GetComponentInChildren<Button>().onClick.AddListener(() => OptionActivation());
        //exit
        quitButton = GameObject.Find("Quit");
        quitButton.GetComponentInChildren<Text>().text = "Quit";
        quitButton.GetComponentInChildren<Button>().onClick.AddListener(() => Application.Quit());
    }
    void OptionActivation()
    {
        global.optionMenu.SetActive(true);
        global.mainMenu.SetActive(false);
    }
    void GalleryActivation()
    {
        global.galleryMenu.SetActive(true);
        global.mainMenu.SetActive(false);
    }


}
