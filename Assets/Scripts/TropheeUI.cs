using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TropheeUI : MonoBehaviour
{
    private Trophee _trophee;
    public Color ColorInitial;
    public Color ColorGris;

    public Image ImageTrophee;
    public Text TextTrophee;
    public void Initialize(Trophee trophee)
    {
        _trophee = trophee;
        ImageTrophee.sprite = trophee.Sprite;
        TextTrophee.text = trophee.Description;
        //ImageTrophee.DOColor(ColorGris, 0.5f);
    }
    public void Update()
    {
        //ImageTrophee.DOColor(ColorGris, 0.5f);
        //for (int i = MainGame.Instance.Trophees.Count - 1; i >= 0; i--)
        //{
        //    if (MainGame.Instance.myMoney >= MainGame.Instance.Trophees[0].unlock)
        //    {
        //         ImageTrophee.DOColor(ColorGris, 0.5f);
        //    }
        //    else
        //    {
        //         ImageTrophee.DOColor(ColorInitial, 0.5f);
        //    }
        //}
        //if (MainGame.Instance.myMoney >= MainGame.Instance.Trophees[0].unlock)
        if (MainGame.Instance.compteurUpgrade >= _trophee.unlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
        }
        else if (MainGame.Instance.totalMoney >= _trophee.moneyForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
        }
        else if (Spawn_PopUp.Instance.howManyBossDied >= _trophee.bossKillForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
        }
        else if (Spawn_PopUp.Instance.howManyDied >= _trophee.popUpKillForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
        }
        else if (MainGame.Instance.compteurClick >= _trophee.clicForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
        }
        else if (Spawn_PopUp.Instance.howManySpeDied >= _trophee.speKillForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
        }
        else
        {
            ImageTrophee.DOColor(ColorGris, 0.5f);
        }
    }
}

[Serializable]
public class Trophee
{
    //public string Name;
    public string Description;
    public Sprite Sprite;
    public int unlock;
    public int moneyForUnlock;
    public int clicForUnlock;
    public int bossKillForUnlock;
    public int popUpKillForUnlock;
    public int speKillForUnlock;
}