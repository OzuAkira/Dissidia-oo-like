using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class charactorIcon : MenuAbstract
{
    [SerializeField] string myName;//各々のObjectに名前を付ける
    GameObject gm;
    CursorMaster cursorMaster;
    public GameObject nextCursor;
    CursorArow cursorArow;
    MenuDataList menuDataList;
    public bool isDummy = false;
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        nextCursor = GameObject.Find("Canvas5").transform.GetChild(0).gameObject;

        cursorMaster = gm.GetComponent<CursorMaster>();
        cursorArow = gm.GetComponent<CursorArow>();
        menuDataList = gm.GetComponent<MenuDataList>();

    }
    
    public override void Select()
    {
        if (isDummy)
        {
            
        }
        else
        {
            gm.GetComponent<MemberSetting>().setCharactor(myName);

            cursorArow.cursorObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(900,0);
            cursorArow.UpdateCursor(nextCursor);//cursorの変更

            //ここのSelect()がトリガーとなってエスケープ処理を起動する
            isDummy = true;

            cursorMaster.changeKey("home");

            //↓”cursorIndexを現在選択しているIconのIndexと同じものにする”↓
            cursorArow.cursorIndex = gm.GetComponent<MemberSetting>().iconObj.GetComponent<Icon>().myIndex;
            cursorArow.UpdateMenu();//charactorSelectListを選択し終えて、Homeに戻った際に、選択したIconのIndexから始まるようにする処理
        }
    }
}
