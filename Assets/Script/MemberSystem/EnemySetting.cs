using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    [SerializeField] string[] keies;
    [SerializeField] GameObject[] windowObj;

    public Dictionary<string,GameObject[]> enemyWindow;

    void Start()
    {
        for(int i = 0; i < keies.Length; i++)
        {
            GameObject[] oneListObj = {gameObject};
            enemyWindow.Add(keies[i],oneListObj);
        }
    }
}
