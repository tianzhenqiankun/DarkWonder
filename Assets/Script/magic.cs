using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour {

    public float magicSpeed = 15;
    public GameObject player;
    Vector3 screenpos ;
    Vector3 e ;
    Vector3 world;
  private  float lifeTime = 3;
	// Use this for initialization
	void Start () {
       player= GameObject.FindGameObjectWithTag("Player");
        screenpos = Camera.main.WorldToScreenPoint(transform.position);
         e= Input.mousePosition;
        e.z = screenpos.z;
        world.x = Camera.main.ScreenToWorldPoint(e).x;
        world.z = Camera.main.ScreenToWorldPoint(e).z;
        world.y = transform.position.y;
        transform.LookAt(world);
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * magicSpeed * Time.deltaTime, transform);
        lifeTime -= Time.deltaTime;
        if (lifeTime<=0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
