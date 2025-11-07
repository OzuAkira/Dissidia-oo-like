using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDataList : MonoBehaviour
{
    static public Dictionary<string, MenuAbstract[]> menuStrage = new Dictionary<string, MenuAbstract[]>();
    static public void addMenu(string keyName , MenuAbstract[] menu)
    {
        menuStrage.Add(keyName, menu);
        Debug.Log("【メニューログ】menuStrageに「"+keyName+"」を追加しました");
    }
}
