using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    private int _life;
    [SerializeField] private int _lifeMax = 100;
    public Text Textlife;

    public Image ImageLife;
    public GameObject Visual;
    public GameObject Croix;
    public Canvas Canvas;

    public GameObject ScrollView;
    //public BoxCollider2D m_BoxCollider;
    public bool canClick;

    public static Monster Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == ScrollView)
        {
            canClick = false;
            Debug.Log("canClick = " + canClick);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == ScrollView)
        {
            canClick = true;
            Debug.Log("canClick = " + canClick);
        }
    }

    public void Updatelife()
    {
        Textlife.text = $"{_life}/{_lifeMax}";

        float percent = (float)_life / (float)_lifeMax;
        ImageLife.fillAmount = percent;
    }
    public void Hit(int damage)
    {
        Croix.transform.DOComplete();
        Croix.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
        _life -= damage;
        
        Updatelife();
    }
    public bool IsAlive()
    {
        return _life > 0;
    }
    public void SetMonster(MonsterInfos infos)
    {
        _lifeMax = infos.Life;
        _life = _lifeMax;
        //Visual.GetComponent<Image>().sprite = infos.Image;
        Updatelife();
    }

}

