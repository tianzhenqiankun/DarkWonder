using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class uiImage : MonoBehaviour {

    public Sprite[] sprites;
    public int i = 0;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().sprite = sprites[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            i++;
            if (i==10)
            {
                SceneManager.LoadScene("mian");
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = sprites[i];
            }
           
        }
	}
}
