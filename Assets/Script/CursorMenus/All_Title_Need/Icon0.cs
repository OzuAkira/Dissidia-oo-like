using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon0 : MenuAbstract
{
    [SerializeField] GameObject nextCursol, gameMaster;
    static public string selectedCharactorName = "";
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
    }
    public override void Select()
    {
        CursorMaster.changeKey("charactorList");
        CursorArow.cursorObject = nextCursol;
        gameMaster.GetComponent<CursorMaster>().menuArray = MenuDataList.menuStrage["charactorList"];
        gameMaster.GetComponent<CursorArow>().UpdateCursor();
    }
}
