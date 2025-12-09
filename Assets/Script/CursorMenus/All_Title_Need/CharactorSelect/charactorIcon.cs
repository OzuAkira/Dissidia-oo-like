using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class charactorIcon : MenuAbstract
{
    public string myName;//各々のObjectに名前を付ける
    GameObject gm;
    CursorMaster cursorMaster;
    public GameObject nextCursor;
    CursorArow cursorArow;
    MenuDataList menuDataList;
    public bool isDummy = false;//MenuDataListから操作する（本スクリプトでは書き換えない）
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        nextCursor = GameObject.Find("Canvas5").transform.GetChild(0).gameObject;

        cursorMaster = gm.GetComponent<CursorMaster>();
        cursorArow = gm.GetComponent<CursorArow>();
        menuDataList = gm.GetComponent<MenuDataList>();

    }
    void Update()
    {

        Image image = GetComponent<Image>();
        Color c = image.color;

        if (isDummy) c = new Color(0.2f, 0.2f, 0.2f);//選択済みのアイコンを構成するObjの色を若干、黒にする
        else c = Color.white;

        image.color = c;
    }
    public override void Select()
    {
        
        if (isDummy)
        {
            Debug.Log("【メニューログ】ダミーアイコンを選択しました");
        }
        else
        {
            gm.GetComponent<MemberSetting>().setCharactor(myName);
            menuDataList.updateCharactorMenu("charactorList");

            cursorArow.cursorObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(900,0);
            cursorArow.UpdateCursor(nextCursor);//cursorの変更

            //ここのSelect()がトリガーとなってエスケープ処理を起動する
            

            cursorMaster.changeKey("home");

            //↓”cursorIndexを現在選択しているIconのIndexと同じものにする”↓
            cursorArow.cursorIndex = gm.GetComponent<MemberSetting>().iconObj.GetComponent<Icon>().myIndex;
            cursorArow.UpdateMenu();//charactorSelectListを選択し終えて、Homeに戻った際に、選択したIconのIndexから始まるようにする処理
        }
    }
}
