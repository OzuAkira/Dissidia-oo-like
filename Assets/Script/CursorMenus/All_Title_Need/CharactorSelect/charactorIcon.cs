using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactorIcon : MenuAbstract
{
    [SerializeField] string myName;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public override void Select()
    {
        
    }
}
