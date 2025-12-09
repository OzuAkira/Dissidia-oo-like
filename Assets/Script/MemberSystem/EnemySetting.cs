using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    MenuDataList menuDataList;
    [SerializeField] GameObject[] windowObj;

    void Start()
    {
        menuDataList = GetComponent<MenuDataList>();
        for(int i = 0; i < windowObj.Length; i++)
        {
            GameObject[] oneListObj = {windowObj[i]};
            menuDataList.addMenu("enemyInformation" , oneListObj);
        }
    }
}
