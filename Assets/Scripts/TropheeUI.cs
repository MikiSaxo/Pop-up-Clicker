using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TropheeUI : MonoBehaviour
{

    public Color ColorInitial;
    public Color ColorGris;

    public Image ImageTrophee;
    public Text TextTrophee;
    public void Initialize(Trophee trophee)
    {
        //_upgrade = upgrade;
        ImageTrophee.sprite = trophee.Sprite;
        TextTrophee.text = trophee.Description;
        ImageTrophee.DOColor(ColorGris, 0.5f);
    }
    public void Update()
    {
        
        /*if (_upgrade.Cost <= MainGame.Instance.myMoney)
        {
             ImageTrophee.DOColor(ColorGris, 0.5f);
        }
        else
        {
            ButtonCost.DOColor(ColorInitial, 0.5f);
        }*/
    }
}

[Serializable]
public class Trophee
{
    //public string Name;
    public string Description;
    public Sprite Sprite;
}