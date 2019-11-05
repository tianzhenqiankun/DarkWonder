using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour {

    public bool isStart = false;
    public float timer = 2f;
    private float resetTimer;
    public bool isTrainingEnd = false;
    public Image SkillImg; 
	// Use this for initialization
	void Start () {
        resetTimer = timer;
        SkillImg.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isStart&&isTrainingEnd==false)
        {
            timer -= Time.deltaTime;
            SkillText._instance.ShowMessage("修炼剩余时间:" + timer.ToString("0.0") + "秒！");
            if (timer<=0)
            {
                isTrainingEnd = true;
                
                SkillImg.gameObject.SetActive(true);
                SkillText._instance.ShowMessage("修炼完成！");
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getMagic = true;
            }
        }
	}
    public void OnTriggerEnter(Collider other)
    {
        isStart = true;
        timer = resetTimer;
        
    }
    public void OnTriggerStay(Collider other)
    {

        
    }
    public void OnTriggerExit(Collider other)
    {
        isStart = false;
        SkillText._instance.Hide();
    }
}
