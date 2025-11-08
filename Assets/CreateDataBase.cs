using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MenuRow
{
    public MenuAbstract[] items; // 1行分
}

[CreateAssetMenu(fileName = "MenuDatabase", menuName = "Game/Menu Database")]
public class MenuDataBase : ScriptableObject
{
    public List<MenuRow> menuRows; // 行のリスト（2次元リスト）
}

