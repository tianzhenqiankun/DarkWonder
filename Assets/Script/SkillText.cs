using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillText : MonoBehaviour {
    public static SkillText _instance;
    public GameObject TextGB;
    private bool beginTimer = false;
    private float timer = 2f;
	// Use this for initialization
	void Start () {
        _instance = this;
        this.gameObject.SetActive(false);
	}
	
    void Update()
    {
        if (beginTimer)
        {
            timer -= Time.deltaTime;
            if (timer<=0)
            {
                Hide();
                beginTimer = false;
            }
        }
    }
    public void ShowMessage(string message)
    {
        TextGB.GetComponent < Text > ().text=message;
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        button._instance.hide();
        this.gameObject.SetActive(false);
    }
    public void ShowMessage(string message,float time)
    {
        TextGB.GetComponent<Text>().text = message;
        this.gameObject.SetActive(true);
        timer = time;
        beginTimer = true;
    }
}
