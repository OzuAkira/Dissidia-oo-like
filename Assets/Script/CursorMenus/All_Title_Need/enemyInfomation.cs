using System.Data.SqlTypes;
using UnityEngine;

public class enemyInfomation : MonoBehaviour
{
    [SerializeField] float margin;//正の値で入力
    RectTransform rectTransform;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0,(rectTransform.sizeDelta.y/2 - margin)*-1);//RectTransformのHeightの値÷2をマイナスにしてY座標にする
    }
}
