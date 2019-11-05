using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour {

    public float timer;
    public bool idle;
    public float speed = 2;
    private float angle;
    public Animator anim;
    private CharacterController CharacterCon;
    public float health = 10;
    private bool death = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        CharacterCon = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (health>0)
        {
            
            if (timer <= 0)
            {
                if (idle)
                {
                    idle = false;
                    timer = 5f;
                    angle = Random.Range(-90, 90);


                }
                else
                {
                    idle = true;
                    timer = 2f;
                    AnimToIdle();
                }
            }
            if (!idle)
            {
                if (angle > 0.2f)
                {
                    float temp = angle * 0.05f;
                    transform.Rotate(new Vector3(0, temp, 0));
                    angle -= temp;
                }
                CharacterCon.SimpleMove(transform.forward * speed);
                AnimToWalk();
            }
        }
        else
        {
            if (!death)
            {
                timer = 3f;
                anim.SetFloat("death", 1.0F);
                if (Random.Range(1,11)>=5)
                {
                    musicManger._instance.getMeat();
                    Meat._instance.getMeat();
                }
                death = true;
            }

        }
        if (health<=0&&timer<=0)
        {
            GameObject.Destroy(gameObject);
            trollSpawn.trollCount--;
        }
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="skill")
        {
            getHurt(5);
        }
    }
    public void AnimToIdle()
    {
        anim.SetFloat("idle", 1f);
        anim.SetFloat("walk", 0);
        anim.SetFloat("get_hit", -1.0F);
    }
    public void AnimToWalk()
    {
        anim.SetFloat("idle", 0);
        anim.SetFloat("walk", 1f);
        anim.SetFloat("get_hit", -1.0F);
    }
    private void getHurt(float hurtNum)
    {
        health -= hurtNum;
        anim.SetFloat("get_hit", 1.0F);
        anim.SetFloat("idle", 0);
        anim.SetFloat("walk", -1f);
        
        timer = 1f;
    }
}
