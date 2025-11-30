using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Icon : MenuAbstract
{
    public string enemyName;
    GameObject gm;
    EnemySetting enemySetting;
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        enemySetting = gm.GetComponent<EnemySetting>();
    }
    public override void Select()
    {
        
    }
}
