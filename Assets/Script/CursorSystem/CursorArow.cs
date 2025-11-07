using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class CursorArow : MonoBehaviour
{
    public GameObject cursorObject;
    public int cursorIndex = 0;
    public MenuAbstract[] menuArray;
    bool isUp = false;
    bool isDown = false;
    RectTransform cursorRect;
    void Start()
    {
        menuArray = MenuDataList.menuStrage["mission1/home"];
        cursorRect = cursorObject.GetComponent<RectTransform>();
        UpdateMenu();
    }

    public void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        if(axis.y == 1 && isDown ==false) isDown = true;//Menuは上から0,1,2と数えるからDown
        else if(axis.y == -1 && isUp ==false) isUp = true;
    }
    void Update()
    {
        int oldCursor = cursorIndex;
        int cursorMax = menuArray.Length;
        if(isUp)
        {
            cursorIndex++;
            isUp = false;
        }
        else if(isDown)
        {
            cursorIndex--;
            isDown = false;
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            menuArray[cursorIndex].Select();
        }


        if(cursorIndex < 0)cursorIndex = menuArray.Length-1;
        if (cursorIndex >= cursorMax) cursorIndex = 0;
        if (cursorIndex != oldCursor) UpdateMenu();
    }
    void OnFire()
    {
       // menu[_cursorIndex].select();
      //  Debug.Log("test");
    }
    public void UpdateMenu()
    {
        int i = 0;
        foreach(MenuAbstract menuTable in menuArray)
        {
            if(cursorIndex == i)
            {
                menuTable.OnImage();
                
                cursorRect.anchoredPosition = menuTable.GetComponent<RectTransform>().anchoredPosition;//あとで消すかも...
            }
            else menuTable.OffImage();
            i++;
        }
    }
}