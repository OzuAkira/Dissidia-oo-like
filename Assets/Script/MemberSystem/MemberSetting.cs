using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberSetting : MonoBehaviour
{
    public GameObject iconObj;

    public string[] nameArray = new string[]{"","",""};

    private int memberIndex;
    public void setIndex(int nowIndex , GameObject nowIconObj)//Iconから呼び出される想定
    {
        memberIndex = nowIndex;
        iconObj = nowIconObj;
    }
    public void setCharactor(string selectName)//charactorIconから呼び出される想定
    {
        nameArray[memberIndex] = selectName;
        iconObj.GetComponent<Icon>().selectedCharactorName = selectName;
    }
}
