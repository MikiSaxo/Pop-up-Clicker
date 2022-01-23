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
    private int oldCost;
    private bool onClickMax = false;
    //private MainGame mainGame;
    private void Start()
    {
        
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
            //onClickMax = false;
            oldCost /= (int)Math.Round(Math.Pow(2, n));
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


    public void OnClickx10()
    {
        
        if (n != 10)
        {
            //onClickMax = false;
            n = 10;
            oldCost = _upgrade.Cost;

            for (int i = 1; i < n+1; i++)
            {
                oldCost += _upgrade.Cost;
                _upgrade.Cost *= 2;
            }
            _upgrade.Cost -= oldCost/ (int)Math.Round(Math.Pow(2, n));

            Debug.Log(oldCost);
            //oldCost = _upgrade.Cost;
        }
        Initialize(_upgrade);
    }
   
    public void OnClickMax()
    {
        //Debug.Log(_upgrade.Cost + _upgrade.Cost * (int)Math.Round(Math.Pow(2, 1)));
        oldCost = _upgrade.Cost;

        //    oldCost = _upgrade.Cost;
            n =5;
        Debug.Log(_upgrade.Cost);
        //onClickMax = true;
        for (int i = 1;i<n+1; i++)
            {
            //n++;
            oldCost += _upgrade.Cost;
            _upgrade.Cost *= 2;
            }
            _upgrade.Cost -= oldCost / (int)Math.Round(Math.Pow(2, n));
        Initialize(_upgrade);

        //oldCost /= (int)Math.Round(Math.Pow(2, n));//for (int i = 1;i<n+2; i++) il faut le n et pas le n+1 donc la le n+1 car il y a n+2
        //oldCost= _upgrade.Cost / (int)Math.Round(Math.Pow(2, n));

        //oldCost= _upgrade.Cost / (int)Math.Round(Math.Pow(2, n));
        //_upgrade.Cost -= oldCost / (int)Math.Round(Math.Pow(2, n));
        //if (MainGame.Instance.myMoney > _upgrade.Cost * (int)Math.Round(Math.Pow(2, n + 1)))
        //{
        //    n++;
        //    oldCost += _upgrade.Cost;
        //    _upgrade.Cost *= 2;
        //}



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
