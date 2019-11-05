using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonWin : MonoBehaviour {

    public static buttonWin _instance;
    // Use this for initialization
    void Start()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }
    public void show()
    {
        this.gameObject.SetActive(true);
    }
    public void hide()
    {
        this.gameObject.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
