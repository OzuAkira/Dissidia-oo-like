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
        nextCursor = GameObject.Find("Canvas15").transform.GetChild(0).gameObject;
    }
    public override void Select()
    {
        gameMaster = GameObject.Find("GameMaster");
        cursorMaster = gameMaster.GetComponent<CursorMaster>();
        cursorArow = gameMaster.GetComponent<CursorArow>();
        menuDataList = gameMaster.GetComponent<MenuDataList>();

        cursorArow.cursorObject = nextCursor;
        
        nextCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);//Debug用
        cursorMaster.changeKey("charactorList");
        
        cursorMaster.menuArray = menuDataList.menuStrage["charactorList"];
        cursorArow.UpdateCursor(nextCursor);
    }
}
