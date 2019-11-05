using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winTrigger : MonoBehaviour {

      void OnTriggerEnter (Collider collider)
        {
            if (collider.tag=="Player")
            {
                SkillText._instance.ShowMessage("游戏胜利!");
                buttonWin._instance.show();
            }
        }
}
