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


    private Upgrade _upgrade;


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
        //MainGame.damageclic += DPS;
        //MainGame.UpdateDamage();
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
