using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;


public class UpgradeUI : MonoBehaviour
{

    public Image Image;
    public Text Text;
    public Text TextCost;
    
    public GameObject ButtonCost;


    private Upgrade _upgrade;
    public UpdateClic UpgradeClic;
    public int n;
    public int m =0;
    private int oldCost;
    private int initCost;
    private bool ClickMax = false;
    public int initUpgrade;
    //public int totalDPS;

    public static UpgradeUI Instance;

    private void Awake()
    {
        Instance = this;
    }
        //private MainGame mainGame;
    public void Start()
    {
        initUpgrade = _upgrade.DPS;
    }

    public void GetValue(Upgrade upgrade)
    {
        initCost = upgrade.Cost;
        m = 1;
    }
    public void Initialize(Upgrade upgrade)
    {
        _upgrade = upgrade;
        Image.sprite = upgrade.Sprite;
        Text.text = upgrade.Name + System.Environment.NewLine + upgrade.Description;
        TextCost.text = upgrade.Cost + "$";
    }
    public void Onclick()
    {
        if (_upgrade.Cost <= MainGame.Instance.myMoney)
        {
            MainGame.Instance.AddUpgrade(_upgrade);
            MainGame.Instance.myMoney -= _upgrade.Cost;
            if (n == 10)
            {
                m += 10;
                MainGame.Instance.totalDPS += _upgrade.DPS;
                _upgrade.DPS += initUpgrade * 10;


                //OnClickx10();
            }
            else if (n == 0)
            {
                ClickMax = false;
                m++;
                Debug.Log("DPS" + _upgrade.DPS);
                MainGame.Instance.totalDPS += _upgrade.DPS;
                _upgrade.DPS += initUpgrade;
                _upgrade.Cost += initCost;
            }
            else
            {
                MainGame.Instance.totalDPS += _upgrade.DPS;
                m += n - 1;
                _upgrade.DPS += initUpgrade * n - 1;
                OnClickxMax();
            }

            //addDPS = _upgrade.DPS;
            //Debug.Log("je veux addDPS svp " + addDPS);

            _upgrade.Description = "Adds " + _upgrade.DPS + " dps";

            Initialize(_upgrade);
            //ButtonCost.SetActive(false); //ça fonctionne ça
        }
    }
    /*public void OnClickUpdateDamage()
    {
        MainGame.Instance.damageOnClick += 1; //a modif

    }*/
 
    public void OnClickx1()
    {
        ClickMax = false;
        _upgrade.Cost = initCost * m;
        n = 0;
        oldCost = _upgrade.Cost;

        Initialize(_upgrade);
    }


    public void OnClickx10()
    {
        ClickMax = false;
        OnClickx1();
        n = 0;
        if (n != 10)
        {
            //onClickMax = false;
            n = 10;

            for (int i = 1; i < n; i++)
            {
                _upgrade.Cost += initCost * m;
                oldCost += _upgrade.Cost;
                //Debug.Log(oldCost);
            }
            _upgrade.Cost = oldCost;
        }
        Initialize(_upgrade);
    }



    public void OnClickxMax()
    {
        OnClickx1();
        n = 1;//pas touche sinon tout cassé :c
        while (oldCost <= MainGame.Instance.myMoney)
        {
            
             _upgrade.Cost += initCost;
             oldCost += _upgrade.Cost;
             n++;
        }
        
        if(n > 1)
        {
            if (m==1)
                oldCost -= initCost * (n);
            else
            {
                oldCost -= _upgrade.Cost;
            }
             _upgrade.Cost = oldCost;
        }      
        else
            OnClickx1();

        Initialize(_upgrade);
        ClickMax = true;
    }


    private void Update()
    {
        if (ClickMax)
            OnClickxMax();
        //Spawn_PopUp.Instance.addDPS = addDPS;
        //Debug.Log("Spawn_PopUp.Instance.addDPS " + Spawn_PopUp.Instance.addDPS);
    }
}

[Serializable]
public class Upgrade
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public int Cost;
    public int DPS;
}
