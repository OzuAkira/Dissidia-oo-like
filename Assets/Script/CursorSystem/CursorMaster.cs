using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorMaster : MonoBehaviour
{
    public string moveKey;//cursorを動かすための指標
    public MenuAbstract[] menuArray;
    [SerializeField] private GameObject[] homeObj;//定数
    [SerializeField] private GameObject[] charactorListObj;//定数
    void Start()
    {
        changeKey("home");
    }
    public void changeKey(string newKey)
    {
        Debug.Log($"【キーログ】moveKyeが「{moveKey}」から「{newKey}」に変更されました");
        moveKey = newKey;

        switch (newKey)
        {
            case "home":
                foreach (GameObject obj in homeObj)
                {
                    obj.SetActive(true);
                }
                foreach(GameObject obj in charactorListObj)
                {
                    obj.SetActive(false);
                }
                break;
            case "charactorList":
                Image image;
                foreach (GameObject obj in homeObj)
                {
                    obj.SetActive(true);

                    image = obj.GetComponent<Image>();
                    Color color = image.color;
                    color = new Color(0.2f, 0.2f, 0.2f);//homeを構成するObjの色を若干、黒にする
                    image.color = color;
                }
                foreach(GameObject obj in charactorListObj)
                {
                    obj.SetActive(true);
                }
                break;

            default:
                Debug.Log("【キーログ】変更したキーは、CursorMasterに登録されていません");
                break;
        }
    }
}
