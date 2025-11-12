using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon0 : MenuAbstract
{
    GameObject nextCursor;
    private GameObject gameMaster;
    public string selectedCharactorName = "";

    CursorMaster cursorMaster;
    CursorArow cursorArow;
    MenuDataList menuDataList;
    void Start()
    {
        nextCursor = GameObject.Find("Canvas15").transform.GetChild(0).gameObject;//これが取れてない
        gameMaster = GameObject.Find("GameMaster");
        cursorArow = gameMaster.GetComponent<CursorArow>();
        cursorMaster = gameMaster.GetComponent<CursorMaster>();
    }
    public override void Select()
    {
        cursorArow.UpdateCursor(nextCursor);
        cursorMaster.changeKey("charactorList");
        
    }
}
