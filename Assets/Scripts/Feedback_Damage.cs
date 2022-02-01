using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Feedback_Damage : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        gameObject.transform.DOMoveY(3, 1);
        text.DOFade(0, 1.5f);
        text.text = "-" + MainGame.Instance.totalDPC;
    }
}
