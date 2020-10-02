using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMenueScript : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject optionMenu;
    [SerializeField] public GameObject galleryMenu;

    void Awake()
    {
        mainMenu = GameObject.Find("CanvasPrincipalMenu");
        optionMenu = GameObject.Find("CanvasOptionMenu");
        galleryMenu = GameObject.Find("GalleryCanvas");
        optionMenu.SetActive(false);
        galleryMenu.SetActive(false);
    }
}
