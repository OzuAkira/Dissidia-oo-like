using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MenuAbstract
{
    GameObject nextCursor;
    private GameObject gameMaster;
    [SerializeField] int myIndex;
    public string selectedCharactorName = "";

    CursorMaster cursorMaster;
    CursorArow cursorArow;
    MemberSetting memberSetting;
    void Start()
    {
        nextCursor = GameObject.Find("Canvas15").transform.GetChild(0).gameObject;//これが取れてない
        gameMaster = GameObject.Find("GameMaster");
        cursorArow = gameMaster.GetComponent<CursorArow>();
        cursorMaster = gameMaster.GetComponent<CursorMaster>();
        
    }
    public override void Select()
    {
        memberSetting = gameMaster.GetComponent<MemberSetting>();
        memberSetting.setIndex(myIndex);
        cursorArow.UpdateCursor(nextCursor);
        cursorMaster.changeKey("charactorList");
        
    }
}
