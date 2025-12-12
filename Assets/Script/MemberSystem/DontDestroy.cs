using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string[] member = {"","",""};
    void Start()
    {
        DontDestroyOnLoad (this);
    }
}
