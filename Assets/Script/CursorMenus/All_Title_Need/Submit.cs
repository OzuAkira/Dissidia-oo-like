using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Submit : MenuAbstract
{
    MemberSetting memberSetting;
    DontDestroy dontDestroy;
    GameObject gm , dd;
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        dd = GameObject.Find("DontDestroy");
        dontDestroy = dd.GetComponent<DontDestroy>();
    }
    public override void Select()
    {
        memberSetting = gm.GetComponent<MemberSetting>();
        if(isStart_f(memberSetting.nameArray))
        {
            Debug.Log("mission Start!");
            for(int i = 0; i < memberSetting.nameArray.Length; i++)
            {
                dontDestroy.member[i] = memberSetting.nameArray[i];   
            }
        SceneManager.LoadScene("mission1-battle");
        }

        else Debug.Log("all charactor null!");
    }
    bool isStart_f(string[] members)
    {
        bool ans = true;
        int num = 0;
        foreach(string name in members)
        {
            if(name == "")num++;
        }
        if(num == members.Length)ans = false;

        return ans;
    }
}
