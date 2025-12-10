using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorMaster : MonoBehaviour
{
    public string moveKey;//cursorを動かすための指標

    [SerializeField] int enemyIndex;//【重要な変数】エネミーアイコンの場所をセットする変数。基本変えない。
    MenuDataList menuDataList;
    CursorArow cursorArow;
    void Start()
    {
        menuDataList = GetComponent<MenuDataList>();
        cursorArow = GetComponent<CursorArow>();
        changeKey("home");
    }
    public void changeKey(string newKey)
    {
        Debug.Log($"【キーログ】moveKyeが「{moveKey}」から「{newKey}」に変更されました");
        moveKey = newKey;
        Image image;
        switch (newKey)
        {
            case "home":
                cursorArow.menuArray = new List<MenuAbstract>();//ここでMenuをリセット
                foreach (GameObject obj in menuDataList.menuStrage["mission1/home"])
                {
                    obj.SetActive(true);
                    image = obj.GetComponent<Image>();
                    Color color = image.color;
                    color = new Color(1,1,1);//homeを構成するObjの色を白にする
                    image.color = color;
                    cursorArow.menuArray.Add(obj.GetComponent<MenuAbstract>());
                }
                foreach (GameObject obj in menuDataList.menuStrage["charactorList"])
                {
                    obj.SetActive(false);
                }

                foreach (GameObject obj in menuDataList.menuStrage["enemy_0_Info"])
                {
                    obj.SetActive(false);
                }

                if(menuDataList.isEnemy2 == true)
                {
                    foreach (GameObject obj in menuDataList.menuStrage["enemy_1_Info"])
                    {
                        obj.SetActive(false);
                    }
                    foreach (GameObject obj in menuDataList.menuStrage["enemy_2_Info"])
                    {
                        obj.SetActive(false);
                    }
                }
                else if(menuDataList.isEnemy1 == true)
                {
                    foreach (GameObject obj in menuDataList.menuStrage["enemy_1_Info"])
                    {
                        obj.SetActive(false);
                    }
                }
                
                break;

            case "charactorList":
                
                foreach (GameObject obj in menuDataList.menuStrage["mission1/home"])
                {
                    obj.SetActive(true);

                    image = obj.GetComponent<Image>();
                    Color color = image.color;
                    color = new Color(0.2f, 0.2f, 0.2f);//homeを構成するObjの色を若干、黒にする
                    image.color = color;
                }

                cursorArow.menuArray = new List<MenuAbstract>();//ここでMenuをリセット

                foreach (GameObject obj in menuDataList.menuStrage["charactorList"])
                {
                    obj.SetActive(true);
                    cursorArow.menuArray.Add(obj.GetComponent<MenuAbstract>());
                }
                break;

            case "enemyInformation":

                int enemyNum = cursorArow.cursorIndex - 3;
                cursorArow.menuArray = new List<MenuAbstract>();

                foreach (GameObject obj in menuDataList.menuStrage["mission1/home"])
                {
                    obj.SetActive(true);

                    image = obj.GetComponent<Image>();
                    Color color = image.color;
                    color = new Color(0.2f, 0.2f, 0.2f);//homeを構成するObjの色を若干、黒にする
                    image.color = color;
                }
                
                foreach(GameObject obj in menuDataList.menuStrage[$"enemy_{cursorArow.cursorIndex - enemyIndex}_Info"])
                {
                    obj.SetActive(true);
                    cursorArow.menuArray.Add(obj.GetComponent<MenuAbstract>());
                }
                break;
            
            default:
                Debug.Log("【キーログ】変更したキーは、CursorMasterに登録されていません");
                break;
        }
        cursorArow.UpdateMenu();
    }
}
