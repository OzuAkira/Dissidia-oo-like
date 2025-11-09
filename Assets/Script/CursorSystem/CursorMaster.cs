using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMaster : MonoBehaviour
{
    static public string moveKey = "home";//cursorを動かすための指標
//homeは初期値
    static public void changeKey(string newKey)
    {
        Debug.Log($"【キーログ】moveKyeが「{moveKey}」から「{newKey}」に変更されました");
        moveKey = newKey;
        
    }
}
