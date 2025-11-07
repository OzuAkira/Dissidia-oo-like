using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDataList : MonoBehaviour
{
    void Awake()
    {
        string sceneName = gameObject.scene.name;
        addMenu(sceneName+"/home", rawData[0]);//Mission開始ボタンやキャラクター選択をするメニュー
        addMenu(sceneName+"/charactorList",rawData[1]);//その枠に入れるキャラクターを選択するメニュー
    }
    [SerializeField] List<MenuAbstract[]> rawData = new List<MenuAbstract[]>();//UnityEditerから変数を代入。ここは気合()
    static public Dictionary<string, MenuAbstract[]> menuStrage = new Dictionary<string, MenuAbstract[]>();
    static public void addMenu(string keyName, MenuAbstract[] menu)
    {
        menuStrage.Add(keyName, menu);
        Debug.Log("【メニューログ】menuStrageに「" + keyName + "」を追加しました");
    }
}
