using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController controller;
    public int Speed = 10;
    public float magicSpeed = 15;
    public bool getMagic=false;
    public float timer = 1f;
    private float timerReset;
    public GameObject magicGB;
    public GameObject trex;
    private bool getControl =true;
    public GameObject ca;
    // Use this for initialization
    void Start () {
        controller = this.GetComponent<CharacterController>();
        timerReset = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (getControl)
        {
            controller.SimpleMove(new Vector3(-Input.GetAxis("Vertical") * Speed, 0, Input.GetAxis("Horizontal") * Speed));
            if (getMagic)
            {
                timer -= Time.deltaTime;
                if (Input.GetButtonDown("Fire1") && timer <= 0)
                {
                    GameObject magic = GameObject.Instantiate(magicGB, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
                    magic.transform.Translate(Vector3.forward * magicSpeed * Time.deltaTime, transform);
                    timer = timerReset;
                }
            }
        }
        if (Input.GetKeyDown("q"))
        {
            int count = trex.GetComponent<Trex>().needCount;
            if (count<=0&&getControl)
            {
                LoseControl();
                trex.GetComponent<Trex>().GetControl();
            }else if(!getControl)
            {
                GetControl();
                trex.GetComponent<Trex>().LoseControl();

            }
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        int count = trex.GetComponent<Trex>().needCount;
        if (collider.tag=="trex"&&count>0)
        {
            if (collider.tag == "trex" && Meat._instance.count == 0)
            {
                SkillText._instance.ShowMessage("恐龙看起来很饿，也许应该给它找一些吃的。。。");
            }
            else if (collider.tag == "trex" && Meat._instance.count != 0)
            {
                SkillText._instance.ShowMessage("恐龙看起来很饿，是否将你身上的巨魔肉喂食给恐龙？");
                button._instance.show();
            }
        }else if (collider.tag == "trex" && count <= 0)
        {
            SkillText._instance.ShowMessage("你已经获得了恐龙的信任，按Q键切换控制！");
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag=="trex")
        {
            
            SkillText._instance.Hide();

        }
    }
    public void GetControl()
    {
        getControl = true;
        ca.SetActive(true);
    }
    public void LoseControl()
    {
        getControl = false;
        ca.SetActive(false);
    }
}
