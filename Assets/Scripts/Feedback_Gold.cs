using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using TMPro;

public class Feedback_Gold : MonoBehaviour
{
    public Text text;
    public Image image;

    private void Start()
    {
        Debug.Log("gold a spawn");
        //var i = Random.Range(-.1f, .1f);
        //Debug.Log("i : " + i);
        gameObject.transform.DOMoveY(.01f, 4f);
        //gameObject.transform.DOMoveX(i, 1.2f);
        //gameObject.transform.DOJump(new Vector2(Random.Range(-2f, 2f), 0), 3, 1, 0.8f).OnComplete(OnDestroyFeedback);
        text.DOFade(0, 1.5f);
        image.DOFade(0, 1.5f).OnComplete(OnDestroyFeedback);
        text.text = "" + Spawn_PopUp.Instance.addMoney * 10;
    }

    private void OnDestroyFeedback()
    {
        Debug.Log("c demo gold");
        Destroy(gameObject);
    }
}
