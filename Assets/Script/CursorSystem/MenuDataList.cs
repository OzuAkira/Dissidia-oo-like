using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDataList : MonoBehaviour
{
    public MenuDataBase menuDataBase;
    void Awake()
    {
        string sceneName = gameObject.scene.name;
        addMenu(sceneName+"/home", menuDataBase.menuRows[0]);//Mission開始ボタンやキャラクター選択をするメニュー
        //addMenu("charactorList",menuDataBase.menuRows[1]);//その枠に入れるキャラクターを選択するメニュー
    }
    
    static public Dictionary<string, MenuAbstract[]> menuStrage = new Dictionary<string, MenuAbstract[]>();
    static public void addMenu(string keyName, MenuRow menu)
    {
        menuStrage.Add(keyName, menu.items);
        Debug.Log("【メニューログ】menuStrageに「" + keyName + "」を追加しました");
    }
}
