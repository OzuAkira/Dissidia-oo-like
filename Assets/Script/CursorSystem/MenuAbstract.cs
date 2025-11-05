using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuAbstract : MonoBehaviour
{
    Image image;
    public Sprite onImage,offImage;
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    public abstract void Select();//決定ボタンを押したときの処理
    void OnImage()
    {
        image.sprite = onImage;
    }
    void OffImage()
    {
        image.sprite = offImage;
    }
}
