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
    // Start is called before the first frame update
    //public void Awake()
    //{
    //    _life = _lifeMax;

    //    Updatelife();
    //}

    // Update is called once per frame
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
        Visual.GetComponent<SpriteRenderer>().sprite = infos.Sprite;
        Updatelife();
    }

}

