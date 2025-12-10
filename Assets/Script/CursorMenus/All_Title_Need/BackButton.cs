using UnityEngine;

public class BackButton : MenuAbstract
{
    CursorArow cursorArow;
    CursorMaster cursorMaster;
    public GameObject homeCursor;
    GameObject gm;
    void Start()
    {

        gm = GameObject.Find("GameMaster");
        cursorArow = gm.GetComponent<CursorArow>();
        cursorMaster = gm.GetComponent<CursorMaster>();
    }
    public override void Select()
    {
        cursorArow = gm.GetComponent<CursorArow>();
        GameObject oldCursor = cursorArow.cursorObject;
        cursorArow.UpdateCursor(homeCursor);
        oldCursor.SetActive(false);
        
        cursorMaster.changeKey("home");
        cursorArow.UpdateMenu();
    }
}
