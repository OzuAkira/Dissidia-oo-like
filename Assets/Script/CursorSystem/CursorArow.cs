using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.InputSystem;

public class CursorArow : MonoBehaviour
{
    
    public GameObject cursorObject;
    public int cursorIndex = 0;
    bool isUp = false, isDown = false, isLeft = false, isRight = false;
    GameObject startCursor;
    RectTransform cursorRect;
    CursorMaster cursorMaster;
    MenuDataList menuDataList;


    public List<MenuAbstract> menuArray = new List<MenuAbstract>();
    void Start()
    {
        startCursor = cursorObject;
        cursorMaster = GetComponent<CursorMaster>();
        menuDataList = GetComponent<MenuDataList>();

        cursorRect = cursorObject.GetComponent<RectTransform>();
        UpdateMenu();
    }

    public void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        if (axis.y == 1 && isDown == false) isUp = true;
        else if (axis.y == -1 && isUp == false) isDown = true;
        else if (axis.x == 1 && isRight == false) isRight = true;
        else if (axis.x == -1 && isLeft == false) isLeft = true;
    }

    [SerializeField] int cl_rowLentgh;//【重要な変数】キャラクターリストのIconが改行する場所を指定している //1_origin で指定すること
    void switchingMethod(string key)//Keyに上記のmoveKeyを参照することで、動的にCursorの動きそのものを変えることが可能
    {
        
        switch (key)
        {
            case "home":
                homeCursor();
                break;
            case "charactorList":
                charactorCursor(cl_rowLentgh);
                break;
            default:
                Debug.Log("");
                break;
        }
    }
    void Update()
    {
        switchingMethod(cursorMaster.moveKey);
    }
    void OnFire()
    {
        menuArray[cursorIndex].Select();
    }
    public void UpdateCursor(GameObject newCursorObj)
    {
        cursorObject = newCursorObj;
        cursorObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);//Debug用
        cursorRect = cursorObject.GetComponent<RectTransform>();
        UpdateMenu();
    }
    public void UpdateMenu()
    {
        int i = 0;
        cursorMaster = GetComponent<CursorMaster>();

        Debug.Log($"rectTransform = (x = {cursorRect.anchoredPosition.x} , y = {cursorRect.anchoredPosition.y})");
        
        foreach (MenuAbstract menuTable in menuArray)
        {
            
            if (cursorIndex == i)
            {
                menuTable.OnImage();

                cursorRect.anchoredPosition = menuTable.GetComponent<RectTransform>().anchoredPosition;//あとで消すかも...
            }
            else menuTable.OffImage();
            i++;
        }
    }

    void homeCursor()
    {
        int oldCursor = cursorIndex;
        int cursorMax = menuArray.Count();
        if (isUp)
        {
            cursorIndex--;
            isUp = false;
        }
        else if (isDown)
        {
            cursorIndex++;
            isDown = false;
        }

        if (cursorIndex < 0) cursorIndex = 0;
        if (cursorIndex >= cursorMax) cursorIndex = menuArray.Count() - 1;
        if (cursorIndex != oldCursor) UpdateMenu();
    }
    
    void charactorCursor(int len_of_row)
    {
        int oldCursor = cursorIndex;
        int cursorMax = menuArray.Count();
        if (isUp)
        {
            cursorIndex -= len_of_row;
            isUp = false;
        }
        else if (isDown)
        {
            cursorIndex += len_of_row;
            isDown = false;
        }
        else if (isLeft)
        {
            cursorIndex--;
            isLeft = false;
        }
        else if(isRight)
        {
            cursorIndex++;
            isRight = false;
        }

        if (cursorIndex < 0) cursorIndex = menuArray.Count() - 1;
        if (cursorIndex >= cursorMax) cursorIndex = 0;
        if (cursorIndex != oldCursor)
        {
            Debug.Log("charactorCursorのupdate");
            UpdateMenu();
        }
    }






}