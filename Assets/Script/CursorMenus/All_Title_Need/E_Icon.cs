using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Icon : MenuAbstract
{
    public string enemyName;
    GameObject gm ;

    public GameObject enemyInfoObj;

    CursorArow cursorArow;
    CursorMaster cursorMaster;
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        cursorArow = gm.GetComponent<CursorArow>();
        cursorMaster = gm.GetComponent<CursorMaster>();

    }
    public override void Select()
    {

        cursorArow.UpdateCursor(enemyInfoObj);//cursorObjectそのものをenemyInformationにする
        cursorMaster.changeKey("enemyInformation");//MoveKey(Menuの更新)のUpdate
        cursorArow.cursorIndex = 0;//indexを初期化
        cursorArow.UpdateMenu();
    }
}
