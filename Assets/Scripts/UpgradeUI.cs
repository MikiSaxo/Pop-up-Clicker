using System;
//using UnityEngine.Mathematics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        if (n == 1)
        {
            //_upgrade.Name = "JeanPierre";
            _upgrade.DPS *= n+1;
            _upgrade.Cost *= n+1;
            _upgrade.Description = "Adds " + _upgrade.DPS + " dps";

        }
        else
        {
            //_upgrade.Name = "JeanPierre";
            _upgrade.DPS *= n;
            _upgrade.Cost *= n;
            _upgrade.Description = "Adds " + _upgrade.DPS + " dps";
        }
        Initialize(_upgrade);
    }
    public void OnClickx1()
    {
        if ( n ==2 )
        {
            n=1;
            //_upgrade.Cost /= Math.Pow(2,n);
        }
        //if (n > 1)
        //{
            //_upgrade.Cost /= Math.Pow(2,n);
        //}
        n = 1;
        //m =_upgrade.DPS*Math.Pow(2,n-1);
        //Debug.Log(m);
       // _upgrade.Description = "Adds " + m + " dps";
        Initialize(_upgrade);
        //        UpdateParameter();
    }
    public void OnClickx10()
    {
        if(n != 5)
        {
            n = 5;
            //Debug.Log(m);
            //m =_upgrade.DPS*Math.Pow(2,n);
            //_upgrade.Cost *= Math.Pow(2,n);
            //_upgrade.Description = "Adds " + m + " dps";
            //      UpdateParameter();
            //Initialize(_upgrade);
        }
    }
   
    public void OnClickMax()
    {
        //if(n > 1)
        //{
            //_upgrade.Cost /=Math.Pow(2,n);
        //}
        //n = 2;
    }
    private void Update()
    {
        //if (n==2)
        //{
            //for(int i =1; MainGame.Instance.myMoney >= m; i++)
            //{
            //     m =_upgrade.DPS*Math.Pow(2,i);
            //}
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
