using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDataList : MonoBehaviour
{
        [SerializeField] private GameObject[] homeObj;//
        [SerializeField] private GameObject[] charactorListObj;//

    void Awake()
    {
        string sceneName = gameObject.scene.name;
        addMenu(sceneName+"/home", homeObj);//Mission開始ボタンやキャラクター選択をするメニュー
        addMenu("charactorList",charactorListObj);//その枠に入れるキャラクターを選択するメニュー
    }
    
    public Dictionary<string, GameObject[]> menuStrage = new Dictionary<string, GameObject[]>();
    public void addMenu(string keyName, GameObject[] menu)
    {
        menuStrage.Add(keyName, menu);
        Debug.Log("【メニューログ】menuStrageに「" + keyName + "」を追加しました");
    }
}
