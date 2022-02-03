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
    public Image ImageBackTrophee;
    public Text TextTrophee;

    public int notifs;
    public void Start()
    {
        notifs = _trophee.notif;
    }
    public void Initialize(Trophee trophee)
    {
        _trophee = trophee;
        //ImageBackTrophee.sprite = trophee.Sprite;
        ImageTrophee.sprite = trophee.Sprite;
        TextTrophee.text = trophee.Description;
    }
    public void Update()
    {
        if (MainGame.Instance.totalMoney >= _trophee.moneyForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
            ImageBackTrophee.DOColor(ColorInitial, 0.5f);
            TaskBarCommands.Instance.numberNotif += notifs;
            notifs = 0;
        }
        else if (MainGame.Instance.compteurClick >= _trophee.clicForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
            ImageBackTrophee.DOColor(ColorInitial, 0.5f);
            TaskBarCommands.Instance.numberNotif += notifs;
            notifs = 0;
        }
        else if (MainGame.Instance.compteurUpgrade >= _trophee.unlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
            ImageBackTrophee.DOColor(ColorInitial, 0.5f);
            TaskBarCommands.Instance.numberNotif += notifs;
            notifs = 0;
        }
        else if (Spawn_PopUp.Instance.howManyDied >= _trophee.popUpKillForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
            ImageBackTrophee.DOColor(ColorInitial, 0.5f);
            TaskBarCommands.Instance.numberNotif += notifs;
            notifs = 0;
        }
        else if (Spawn_PopUp.Instance.howManyBossDied >= _trophee.bossKillForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
            ImageBackTrophee.DOColor(ColorInitial, 0.5f);
            TaskBarCommands.Instance.numberNotif += notifs;
            notifs = 0;
        }
        else if (Spawn_PopUp.Instance.howManySpeDied >= _trophee.speKillForUnlock)
        {
            ImageTrophee.DOColor(ColorInitial, 0.5f);
            ImageBackTrophee.DOColor(ColorInitial, 0.5f);
            TaskBarCommands.Instance.numberNotif += notifs;
            notifs = 0;
        }
        else
        {
            ImageTrophee.DOColor(ColorGris, 0.5f);
            ImageBackTrophee.DOColor(ColorGris, 0.5f);
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
    public int notif = 1;
}