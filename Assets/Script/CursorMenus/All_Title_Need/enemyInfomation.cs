using System.Data.SqlTypes;
using UnityEngine;

public class enemyInfomation : MenuAbstract
{
    [SerializeField] float margin;//正の値で入力
    RectTransform rectTransform;

    CursorArow cursorArow;
    GameObject gm;
    public GameObject emptyObj;
    bool isOver;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        rectTransform = GetComponent<RectTransform>();
        cursorArow = gm.GetComponent<CursorArow>();

        if(rectTransform.sizeDelta.y > 390)
        {
            isOver = true;
            rectTransform.anchoredPosition = new Vector2(0,(rectTransform.sizeDelta.y/2 + margin)*-1);//RectTransformのHeightの値÷2をマイナスにしてY座標にする
        }
        else
        {
            isOver = false;
            rectTransform.anchoredPosition = new Vector2(0,-225);//カメラに映る範囲の縦の長さが450なので、その半分の-225の座標に移動
        }
        cursorArow.UpdateCursor(emptyObj);
        cursorArow.setObject(gameObject);
        cursorArow.set_Radius_and_Margin(rectTransform.sizeDelta.y/2 , margin , isOver);
    }
    public override void Select()
    {
        
    }
}
