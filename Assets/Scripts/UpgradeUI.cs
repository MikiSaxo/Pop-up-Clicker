using System;
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
        MainGame.Instance.AddUpgrade(_upgrade);

        //ButtonCost.SetActive(false); //ça fonctionne ça
        //UpdateParameter();
    }
    public void OnClickUpdateDamage()
    {
        MainGame.Instance.damageClic += 1; //a modif

    }
    //public void UpdateParameter()
    //{
    //    //_upgrade.Name = "JeanPierre";
    //    _upgrade.DPS *= 2;
    //    _upgrade.Cost *= 1.5f;
    //    _upgrade.Description = "Add " + _upgrade.DPS + " dps";
    //    Initialize(_upgrade);
    //}
}

[Serializable]
public class Upgrade
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public float Cost;
    public int DPS;


}
