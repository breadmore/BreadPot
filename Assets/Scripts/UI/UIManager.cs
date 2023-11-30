using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainUI;
    private GameObject nowOpenUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // UI Open 할 때 실행 (Main UI 닫음)
    private void UIOpen()
    {
        mainUI.SetActive(false);
    }

    // UI Close 할 때 실행
    private void UIClose()
    {
        mainUI.SetActive(true);
    }

    public void UIOpenWithObject(GameObject uiObject)
    {
        UIOpen();
        nowOpenUI = uiObject;
        uiObject.SetActive(true);
    }

    public void UICloseWithObject()
    {

        nowOpenUI.SetActive(false);

        UIClose();
    }
}
