using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using DG.Tweening;

public class UpgradeUI : MonoBehaviour
{

    public Image Image;
    public Text Text;
    public Text TextCost;

    public Image ButtonCost;
    public Color ColorInitial;
    public Color ColorAsserDeThune;

    private Upgrade _upgrade;
    public int n;
    public int m = 0;
    private int oldCost;
    private int initCost;
    private bool ClickMax = false;
    public int initUpgrade;
    private int oldUpgrade;
    private int oldUpgradeDPC;
    public int initUpgradeDPC;



    public static UpgradeUI Instance;

    private void Awake()
    {
        Instance = this;
    }
    //private MainGame mainGame;
    public void Start()
    {
        initUpgrade = _upgrade.DPS;
        initUpgradeDPC = _upgrade.DPC;
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
        Text.text = upgrade.Name + System.Environment.NewLine + "( Lvl : " + m + " )" + System.Environment.NewLine + upgrade.Description;
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

                MainGame.Instance.totalDPC += _upgrade.DPC;
                MainGame.Instance.compteurUpgrade += 10;
                OnClickx10();
            }
            else if (n == 0)
            {
                ClickMax = false;
                m++;
                MainGame.Instance.totalDPS += _upgrade.DPS;
                MainGame.Instance.totalDPC += _upgrade.DPC;
                _upgrade.Cost += initCost;
                MainGame.Instance.compteurUpgrade++;
                OnClickx1();
            }
            else
            {
                MainGame.Instance.totalDPS += _upgrade.DPS;
                MainGame.Instance.totalDPC += _upgrade.DPC;
                m += n - 1;
                MainGame.Instance.compteurUpgrade += n - 1;
                OnClickxMax();
            }

            Sound_Script.Instance.PlayAchat();


            Initialize(_upgrade);
            //ButtonCost.SetActive(false); //?a fonctionne ?a
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
        _upgrade.DPS = initUpgrade * m;
        _upgrade.DPC = initUpgradeDPC;
        n = 0;
        oldCost = _upgrade.Cost;
        oldUpgrade = _upgrade.DPS;
        //oldUpgradeDPC = _upgrade.DPC;
        if (_upgrade.DPC > 0)
            _upgrade.Description = "Adds " + _upgrade.DPC + " dpc";
        else
            _upgrade.Description = "Adds " + _upgrade.DPS + " dps";
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
                _upgrade.DPS += initUpgrade * m;
                oldUpgrade += _upgrade.DPS;
                _upgrade.DPC = initUpgradeDPC * 10;
            }

            _upgrade.DPS = oldUpgrade;
            _upgrade.Cost = oldCost;
            if (_upgrade.DPC > 0)
                _upgrade.Description = "Adds " + _upgrade.DPC + " dpc";
            else
                _upgrade.Description = "Adds " + _upgrade.DPS + " dps";
        }
        Initialize(_upgrade);
    }



    public void OnClickxMax()
    {
        OnClickx1();
        n = 1;//pas touche sinon tout cass? :c
        while (oldCost <= MainGame.Instance.myMoney)
        {

            _upgrade.Cost += initCost;
            oldCost += _upgrade.Cost;

            _upgrade.DPS += initUpgrade;
            oldUpgrade += _upgrade.DPS;
            _upgrade.DPC += initUpgradeDPC;
            n++;
        }
        if (n > 1)
        {
            if (m == 1)
            {
                oldCost -= initCost * (n);
                oldUpgrade -= initUpgrade * (n);
            }
            else
            {
                oldCost -= _upgrade.Cost;
                oldUpgrade -= _upgrade.DPS;
            }
            _upgrade.DPC -= initUpgradeDPC;
            _upgrade.Cost = oldCost;
            _upgrade.DPS = oldUpgrade;
        }
        else
            OnClickx1();

        if (_upgrade.DPC > 0)
            _upgrade.Description = "Adds " + _upgrade.DPC + " dpc";
        else
            _upgrade.Description = "Adds " + _upgrade.DPS + " dps";

        Initialize(_upgrade);
        ClickMax = true;
    }


    private void Update()
    {
        if (ClickMax)
            OnClickxMax();

        if (_upgrade.Cost <= MainGame.Instance.myMoney)
        {
            ButtonCost.DOColor(ColorAsserDeThune, 0.5f);
        }
        else
        {
            ButtonCost.DOColor(ColorInitial, 0.5f);
        }
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
    public int DPC;
}
