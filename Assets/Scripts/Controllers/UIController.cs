using System;
using UnityEngine;

public class UIController : MonoBehaviour 
{
    [SerializeField] Canvas options;

    void Start()
    {
        options = GameObject.Find("CanvasOptionMenu").GetComponent<Canvas>();
        options.enabled = false;
    }
    public void OptionActivation()
    {
        Time.timeScale = 0;
        options.GetComponent<Canvas>().enabled = true;
    }

}