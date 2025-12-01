using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Icon : MenuAbstract
{
    public string enemyName;
    GameObject gm , myInformation;

    public GameObject emptyObj;

    MenuDataList menuDataList;
    CursorArow cursorArow;
    CursorMaster cursorMaster;
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        menuDataList = gm.GetComponent<MenuDataList>();
        cursorArow = gm.GetComponent<CursorArow>();
        cursorMaster = gm.GetComponent<CursorMaster>();

    }
    public override void Select()
    {

        cursorArow.UpdateCursor(emptyObj);//cursorの変更
        cursorMaster.changeKey("enemyInformation");//MoveKeyのUpdate
        cursorArow.cursorIndex = 0;//indexを初期化
        cursorArow.UpdateMenu();
    }
}
