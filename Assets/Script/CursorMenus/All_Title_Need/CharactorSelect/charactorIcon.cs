using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactorIcon : MenuAbstract
{
    [SerializeField] string myName;//各々のObjectに名前を付ける
    GameObject gm;
    void Start()
    {
        gm = GameObject.Find("GameMaster");
    }
    public override void Select()
    {
        gm.GetComponent<MemberSetting>().setCractor(myName);
    }
}
