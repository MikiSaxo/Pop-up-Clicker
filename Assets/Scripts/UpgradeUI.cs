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
    private int n;
    private int m;
    //private MainGame mainGame;

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
            UpdateParameter();
            //ButtonCost.SetActive(false); //ça fonctionne ça
        }
    }
    public void OnClickUpdateDamage()
    {
        MainGame.Instance.damageClic += 1; //a modif

    }
    public void UpdateParameter()
    {
        
        //_upgrade.Name = "JeanPierre";
        _upgrade.DPS *= 2; 
        //_upgrade.Cost *= (int)Math.Round(Math.Pow(2, n+2)); 
        _upgrade.Cost *= 2; 
        _upgrade.Description = "Adds " + _upgrade.DPS + " dps";

        //else if (n==1)
        //{
        //    //_upgrade.Name = "JeanPierre";
        //    _upgrade.DPS *= (int)Math.Round(Math.Pow(2, n+1));
        //    _upgrade.Cost *= (int)Math.Round(Math.Pow(2, n+1));
        //    _upgrade.Description = "Adds " + _upgrade.DPS + " dps";

        //}
        //else
        //{
        //    //_upgrade.Name = "JeanPierre";
        //    _upgrade.DPS *= (int)Math.Round(Math.Pow(2, n));
        //    _upgrade.Cost *= (int)Math.Round(Math.Pow(2, n));
        //    _upgrade.Description = "Adds " + _upgrade.DPS + " dps";
        //}
        Initialize(_upgrade);
    }
    public void OnClickx1()
    {
        if ( n !=0 )
        {
            oldCost/= (int)Math.Round(Math.Pow(2, n));
            _upgrade.Cost = oldCost;
            n = 0;
        //    n=1;
        //    _upgrade.Cost /= (int)Math.Round(Math.Pow(2, n));
        }
        //if (n > 1)
        //{
        //    _upgrade.Cost /= (int)Math.Round(Math.Pow(2, n));
        //}
        //n = 0;
        //m = _upgrade.DPS * (int)Math.Round(Math.Pow(2, n));
        Debug.Log(oldCost);
        //_upgrade.Description = "Adds " + m + " dps";
        Initialize(_upgrade);
        //        UpdateParameter();
    }


    int oldCost = 0;//test 
    public void OnClickx10()
    {
        
        ////_upgrade.Cost = ((_upgrade.Cost * 1) * (_upgrade.Cost * 5)) / 2;
        if (n != 10)
        {
            n = 10;
            oldCost = _upgrade.Cost;
            //_upgrade.Cost = ((_upgrade.Cost * n) * (_upgrade.Cost * n + 1))/2;
            for (int i = 1; i < n+1; i++)
            {
                
                oldCost += _upgrade.Cost;
                _upgrade.Cost *= 2;
                //_upgrade.Cost *= (int)Math.Round(Math.Pow(2, n));
                //_upgrade.Cost = ((_upgrade.Cost * i) * (_upgrade.Cost * i + 1)) / 2;
            }
            _upgrade.Cost -= oldCost/ (int)Math.Round(Math.Pow(2, n));
        //_upgrade.Cost -= _upgrade.Cost/(int)Math.Round(Math.Pow(2, n));
        //            m = _upgrade.DPS * (int)Math.Round(Math.Pow(2, n));

        //            _upgrade.Description = "Adds " + m + " dps";
        //UpdateParameter();
        //Initialize(_upgrade);
        }
        Initialize(_upgrade);
    }
   
    public void OnClickMax()
    {
        //if (n > 1)
        //{
        //    _upgrade.Cost /= (int)Math.Round(Math.Pow(2, n));
        //}
        //n = 2;
    }
    private void Update()
    {
//        Debug.Log(n);
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
