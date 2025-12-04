using System.Data.SqlTypes;
using UnityEngine;

public class enemyInfomation : MenuAbstract
{
    [SerializeField] float margin;//正の値で入力
    RectTransform rectTransform;

    CursorArow cursorArow;
    GameObject gm;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        gm = GameObject.Find("GameMaster");
        rectTransform = GetComponent<RectTransform>();
        cursorArow = gm.GetComponent<CursorArow>();

        rectTransform.anchoredPosition = new Vector2(0,(rectTransform.sizeDelta.y/2 - margin)*-1);//RectTransformのHeightの値÷2をマイナスにしてY座標にする

        cursorArow.set_Radius_and_Margin(rectTransform.sizeDelta.y/2,margin);
    }
    public override void Select()
    {
        Debug.Log("【なにもないよ】");
    }
}
