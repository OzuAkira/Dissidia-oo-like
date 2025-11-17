using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberSetting : MonoBehaviour
{
    public GameObject iconObj;

    public string[] nameArray;

    private int memberIndex;
    public void setIndex(int nowIndex)//Iconから呼び出される想定
    {
        memberIndex = nowIndex;
    }
    public void setCractor(string selectName)//charactorIconから呼び出される想定
    {
        nameArray[memberIndex] = selectName;
    }
}
