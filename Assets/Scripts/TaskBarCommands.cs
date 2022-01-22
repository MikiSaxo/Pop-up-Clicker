using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TaskBarCommands : MonoBehaviour
{
    public GameObject MenuNotifs;
    public bool isNotifOpen;

    public static TaskBarCommands Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnClickOpenNotifs()
    {
        if (isNotifOpen)
        {
            MenuNotifs.transform.DOComplete();
            MenuNotifs.transform.DOMoveX(4, 1);
            isNotifOpen = false;
        }
        else
        {

            //Shop.SetActive(true);
            MenuNotifs.transform.DOComplete();
            MenuNotifs.transform.DOMoveX(0, 1);
            isNotifOpen = true;
        }
    }
}
