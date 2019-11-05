using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meat : MonoBehaviour {

    public static Meat _instance;
    public int count = 0;
	// Use this for initialization
	void Start () {
        _instance = this;
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void getMeat()
    {
        this.gameObject.SetActive(true);
        count++;
        this.GetComponentInChildren<Text>().text = count.ToString();
    }
    public void loseMeat()
    {
        count--;
        this.GetComponentInChildren<Text>().text = count.ToString();
        if (count<=0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
