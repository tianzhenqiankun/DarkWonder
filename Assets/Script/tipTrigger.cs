using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipTrigger : MonoBehaviour {

  
    public GameObject fance1;
    public bool isDestroy = false;

    void OnTriggerEnter(Collider cc)
    {
        if (cc.tag=="Player"&&isDestroy!=true)
        {
            SkillText._instance.ShowMessage("你的力量无法打开栅栏，也许可以借助恐龙的力量。。。",3f);
        }
    }
    public  void  Destroy()
    {
        GameObject.Destroy(fance1);
        isDestroy = true;
    }
}
