using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManger : MonoBehaviour {

    public static musicManger _instance;
    public AudioClip[] sound;
	// Use this for initialization
	void Start () {
        _instance = this;
	}
	
   public void getMeat()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound[0]);
    }
    public void getTrex()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound[1]);
    }
}
