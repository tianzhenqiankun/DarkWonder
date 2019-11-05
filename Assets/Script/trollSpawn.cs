using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollSpawn : MonoBehaviour {

    public GameObject trollPrefab;
    public static int trollCount=0;
    public static int MaxTrollCount = 5;
    public float timer=5;
    public float timerReset;
	// Use this for initialization
	void Start () {
        timerReset = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (trollCount<MaxTrollCount)
        {
            timer -= Time.deltaTime;
            if (timer<0)
            {
                GameObject.Instantiate(trollPrefab, transform.position, Quaternion.identity);
                trollCount++;
                timer = timerReset;
            }
        }
	}
}
