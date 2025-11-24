using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactorIcon : MenuAbstract
{
    [SerializeField] string myName;//各々のObjectに名前を付ける
    GameObject gm;
    CursorMaster cursorMaster;
    public GameObject nextCursor;
    CursorArow cursorArow;
    MenuDataList menuDataList;
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
        gm.GetComponent<MemberSetting>().setCharactor(myName);

        cursorArow.cursorObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(900,0);
        cursorArow.UpdateCursor(nextCursor);//cursorの変更

        //ここのSelect()がトリガーとなってエスケープ処理を起動する
        GameObject[] cloneArray = menuDataList.menuStrage["charactorList"];

        cursorMaster.changeKey("home");

        //↓”cursorIndexを現在選択しているIconのIndexと同じものにする”↓
        cursorArow.cursorIndex = gm.GetComponent<MemberSetting>().iconObj.GetComponent<Icon>().myIndex;
        cursorArow.UpdateMenu();//charactorSelectListを選択し終えて、Homeに戻った際に、選択したIconのIndexから始まるようにする処理
    }
}
