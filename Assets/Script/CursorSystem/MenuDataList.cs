using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDataList : MonoBehaviour
{
    [SerializeField] GameObject escapeObj ;//選択したキャラクターの場所に置くObj
    [SerializeField] private GameObject[] homeObj;//
    [SerializeField] private GameObject[] charactorListObj;//

    [SerializeField] GameObject[] enemy_0_InfoObj , enemy_1_InfoObj , enemy_2_InfoObj;//各敵の情報を入れる
    [SerializeField] GameObject backObj;//戻るボタン

    void Awake()
    {
        string sceneName = gameObject.scene.name;
        addMenu(sceneName+"/home", homeObj);//Mission開始ボタンやキャラクター選択をするメニュー
        addMenu("charactorList",charactorListObj);//その枠に入れるキャラクターを選択するメニュー

        
        addMenu("enemy_0_Info",enemy_0_InfoObj);
        if(enemy_1_InfoObj != null)addMenu("enemy_1_Info",enemy_1_InfoObj);
        if(enemy_2_InfoObj != null)addMenu("enemy_2_Info",enemy_2_InfoObj);
    }
    
    public Dictionary<string, GameObject[]> menuStrage = new Dictionary<string, GameObject[]>();
    public void addMenu(string keyName, GameObject[] menu)
    {
        menuStrage.Add(keyName, menu);
        Debug.Log("【メニューログ】menuStrageに「" + keyName + "」を追加しました");
    }
    public void updateCharactorMenu(string keyName)
    {
        
        switch(keyName)
        {
            case "charactorList":

                MemberSetting memberSetting = GetComponent<MemberSetting>();
                foreach(GameObject icon in menuStrage["charactorList"])
                {
                    charactorIcon charactorIcon = icon.GetComponent<charactorIcon>();
                    foreach(string name in memberSetting.nameArray)
                    {
                        if(name == charactorIcon.myName)
                        {
                            charactorIcon.isDummy = true;
                            
                            break;
                        }
                        else charactorIcon.isDummy = false;
                    }
                }
                
                break;
        }
        Debug.Log($"【メニューログ】menuStrageの「{keyName}」を更新しました");
    }
}
