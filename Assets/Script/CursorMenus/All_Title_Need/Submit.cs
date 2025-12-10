using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit : MenuAbstract
{
    MemberSetting memberSetting;
    GameObject gm;
    void Start()
    {
        gm = GameObject.Find("GameMaster");

        memberSetting = gm.GetComponent<MemberSetting>();
    }
    public override void Select()
    {
        
    }
}
