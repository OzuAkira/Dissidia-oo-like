using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MenuAbstract
{
    GameObject nextCursor;
    private GameObject gameMaster;
    public int myIndex;
    public string selectedCharactorName = "";

    CursorMaster cursorMaster;
    CursorArow cursorArow;
    MemberSetting memberSetting;
    void Start()
    {
        nextCursor = GameObject.Find("Canvas15").transform.GetChild(0).gameObject;
        gameMaster = GameObject.Find("GameMaster");
        cursorArow = gameMaster.GetComponent<CursorArow>();
        cursorMaster = gameMaster.GetComponent<CursorMaster>();
        memberSetting = gameMaster.GetComponent<MemberSetting>();
    }
    public override void Select()
    {
        memberSetting = gameMaster.GetComponent<MemberSetting>();
        memberSetting.setIndex(myIndex,gameObject);

        cursorArow.UpdateCursor(nextCursor);//cursorの変更
        cursorMaster.changeKey("charactorList");//MoveKeyのUpdate
        cursorArow.cursorIndex = 0;//indexを初期化
        cursorArow.UpdateMenu();
    }
    
}
