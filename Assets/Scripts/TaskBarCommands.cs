using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskBarCommands : MonoBehaviour
{
    public GameObject MenuNotifs;
    public bool isNotifOpen;
    public int numberNotif = 0;
    public Text TextNotif;
    public Text TextDPC;
    public Text TextDPS;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;


    public static TaskBarCommands Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        Button5.SetActive(false);
        Button6.SetActive(false);
        Button7.SetActive(false);
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
            MenuNotifs.transform.DOComplete();
            MenuNotifs.transform.DOMoveX(0, 1);
            isNotifOpen = true;
            numberNotif = 0;
        }
    }
    private void Update()
    {
        TextNotif.text = ""+ numberNotif;
        TextDPC.text = "DPC : "+MainGame.Instance.totalDPC;
        TextDPS.text = "DPS : "+MainGame.Instance.totalDPS;

        /* Pas opti du tout mais ça fonctionne apres faudra voir car si le joueur achete le 2 en premier bah il sera pas 
          en premier dans la barre apres qu'il achete le 1*/
        int position = 0;
        if (MainGame.Instance._unlockedUpgrades.Count > 0)
        {
            for (int i = 0; i < MainGame.Instance._unlockedUpgrades.Count; i++)
            {
                if (MainGame.Instance._unlockedUpgrades[i] != MainGame.Instance.Upgrades[0])
                    position = i;
            }


            if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[1])
            {
                Button1.SetActive(true);
            }
            else if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[2])
            {
                Button2.SetActive(true);
            }
            else if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[3])
            {
                Button3.SetActive(true);
            }
            else if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[4])
            {
                Button4.SetActive(true);
            }
            else if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[5])
            {
                Button5.SetActive(true);
            }
            else if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[6])
            {
                Button6.SetActive(true);
            }
            else if (MainGame.Instance._unlockedUpgrades[position] == MainGame.Instance.Upgrades[7])
            {
                Button7.SetActive(true);
            }
        }
    }
}
