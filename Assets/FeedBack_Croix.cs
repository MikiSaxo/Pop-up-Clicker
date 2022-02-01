using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FeedBack_Croix : MonoBehaviour
{
    public Image image;
    public Color ColorInitial;
    public Color ColorSelected;

    public void OnPointerEnter()
    {
        image.DOKill();
        Debug.Log("rentre");
        image.DOColor(ColorSelected, 0.2f);
    }
    public void OnPointerExit()
    {
        image.DOKill();
        image.DOColor(ColorInitial, 0.2f);
    }
}
