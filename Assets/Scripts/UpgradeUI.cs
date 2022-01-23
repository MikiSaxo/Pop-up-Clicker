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
    public int m = 1;
    private int oldCost;
    private int initCost;
    private bool onClickMax = false;
    //private MainGame mainGame;
    public void GetValue(Upgrade upgrade)
    {
        initCost = upgrade.Cost;
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
                _upgrade.DPS += 2 * 10;

                //_upgrade.Cost *= oldCost;
                //OnClickx1();
                OnClickx10();
            }
            else if (n == 0)
            {
                m++;
                _upgrade.DPS += 2;
                _upgrade.Cost += initCost;
            }
            else
            {
                
                m += n - 1;
                _upgrade.DPS += 2 * n - 1;
                
                //_upgrade.Cost *= oldCost;
                //OnClickx1();
                OnClickxMax();
            }


            _upgrade.Description = "Adds " + _upgrade.DPS + " dps";

            Initialize(_upgrade);
            //ButtonCost.SetActive(false); //ça fonctionne ça
        }
    }
    public void OnClickUpdateDamage()
    {
        MainGame.Instance.damageClic += 1; //a modif

    }
 
    public void OnClickx1()
    {
        //Debug.Log(m);
        _upgrade.Cost = initCost * m;
        n = 0;
        oldCost = _upgrade.Cost;
        //Debug.Log(initCost);

        Initialize(_upgrade);

    }


    public void OnClickx10()
    {
        OnClickx1();
        n = 0;
        if (n != 10)
        {
            //onClickMax = false;
            n = 10;
            //oldCost = _upgrade.Cost;

            for (int i = 1; i < n; i++)
            {
                _upgrade.Cost += initCost*m;
                oldCost += _upgrade.Cost;
                //_upgrade.Cost = oldCost;
                Debug.Log(oldCost);
            }
            _upgrade.Cost = oldCost;

            //oldCost = _upgrade.Cost;
        }
        Initialize(_upgrade);
    }
   
    public void OnClickxMax()
    {
        OnClickx1();
        n = 1;//pas touche sinon tout cassé :c
        //oldCost = _upgrade.Cost;
        Debug.Log(oldCost);
        Debug.Log(_upgrade.Cost);
        Debug.Log(initCost);
        while (oldCost <= MainGame.Instance.myMoney)
        {
            
             _upgrade.Cost += initCost;
             oldCost += _upgrade.Cost;
            //if (oldCost< MainGame.Instance.myMoney)
             n++;
            //else
            //{
            //oldCost -= _upgrade.Cost;
            //}
        }
            Debug.Log(oldCost);
            Debug.Log(_upgrade.Cost);
            Debug.Log(MainGame.Instance.myMoney);
        
        if(n > 1)
        {
            if (m==1)
                oldCost -= initCost * (n);//m=1 it's good
            else
            {
                oldCost -= _upgrade.Cost;
            }
            //oldCost -= initCost * (n+1);
            Debug.Log(n);
             Debug.Log(m);
             Debug.Log(oldCost);
             Debug.Log(_upgrade.Cost);
             _upgrade.Cost = oldCost;

        }      
        else
            OnClickx1();

        Initialize(_upgrade);
    }


    private void Update()
    {
        //if (onClickMax == true)
        //{
        //    n = 1;
        //    if (MainGame.Instance.myMoney > _upgrade.Cost * (int)Math.Round(Math.Pow(2, n + 1)))
        //    {
        //        n++;
        //    }
        //}
        //Debug.Log(onClickMax);
        //Debug.Log(61f/7f);
        //Debug.Log(oldCost);
        //if (n == 2)
        //{

        //    for (int i = 1; MainGame.Instance.myMoney >= m; i++)
        //    {

        //        m = _upgrade.DPS * (int)Math.Round(Math.Pow(2, i));
        //        _upgrade.Description = "Adds " + m + " dps";
        //        _upgrade.Cost /= (int)Math.Round(Math.Pow(2, i));
        //    }
        //}

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
