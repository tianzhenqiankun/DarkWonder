using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trex : MonoBehaviour {
    public CharacterController cc;
    public float speed = 20;
    public Animation animation;
    private string courrentAni="idle";
    private bool getControl=false;
    public int needCount = 2;
    public GameObject ca;
	// Use this for initialization
	void Start () {
        cc = this.GetComponent<CharacterController>();
        animation = this.GetComponentInChildren<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        if (getControl)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * 50 * Time.deltaTime, 0));
            cc.SimpleMove(transform.forward * speed * Input.GetAxis("Vertical"));
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            {
                if (courrentAni != "walk_loop")
                {
                    animation.CrossFade("walk_loop");
                    courrentAni = "walk_loop";
                }

            }
            else
            {
                if (courrentAni != "idle")
                {
                    animation.CrossFade("idle");
                    courrentAni = "idle";
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                animation.CrossFade("hit");
            }
        }

	}

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag=="tipTrigger")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                collider.GetComponent<tipTrigger>().Destroy();
            }
        }
    }
    public void Feed()
    {
        needCount--;
        Meat._instance.loseMeat();
        if (needCount<=0)
        {
            musicManger._instance.getTrex();
            SkillText._instance.ShowMessage("你已经获得了恐龙的信任，按Q键切换控制！");
            button._instance.hide();
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
