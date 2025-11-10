using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon0 : MenuAbstract
{
    [SerializeField] GameObject nextCursol, gameMaster;
    public string selectedCharactorName = "";

    CursorMaster cursorMaster;
    CursorArow cursorArow;
    MenuDataList menuDataList;
    void Start()
    {

    }
    public override void Select()
    {
        gameMaster = GameObject.Find("GameMaster");
        cursorMaster = gameMaster.GetComponent<CursorMaster>();
        cursorArow = gameMaster.GetComponent<CursorArow>();
        menuDataList = gameMaster.GetComponent<MenuDataList>();

        Debug.Log(nextCursol == null);
        cursorArow.cursorObject = nextCursol;
        cursorMaster.changeKey("charactorList");
        
        cursorMaster.menuArray = menuDataList.menuStrage["charactorList"];
        cursorArow.UpdateCursor();
    }
}
