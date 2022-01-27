using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUp_Script : MonoBehaviour
{
    public Sprite m_Sprite;
    private int _life;
    [SerializeField] private int _lifeMax = 100;
    public Text Textlife;
    public Image ImageLife;
    public Image ImagePopUp;
    public GameObject Croix;
    public Rigidbody2D rb;
    public int MoveInZ = -1;
    public GameObject PopUpPrefab;
    public GameObject Feedback;
    //public bool isBoss;



    public static PopUp_Script Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Debug.Log("yo le spawn de popup");
        //if (!isBoss)
        //{
        var i = Random.Range(1, Spawn_PopUp.Instance.popUpSprites.Count);
        //Debug.Log("random number for sprite pop up : " + i);
        m_Sprite = Spawn_PopUp.Instance.popUpSprites[i];
        ImagePopUp.sprite = m_Sprite;
        //Debug.Log("Sprite popup" + m_Sprite);
        _lifeMax = Spawn_PopUp.Instance._lifeOfPopUp;
        _life = _lifeMax;
        Updatelife();
        //}
        /*else
        {
             Debug.Log("bonjour c'est le boss");
             m_Sprite = Spawn_PopUp.Instance.popUpSprites[0];
             ImagePopUp.sprite = m_Sprite;
             _lifeMax = Spawn_PopUp.Instance._lifeOfPopUp;
             _life = _lifeMax;
             Updatelife();
             isBoss = false;
             Spawn_PopUp.Instance._lifeOfPopUp -= 100;
             Spawn_PopUp.Instance.isBoss = false;
        }*/
    }

    public void OnClickCroix()
    {
        //Spawn_PopUp.Instance.HasClickCroix();
        Hit(Spawn_PopUp.Instance.damageOnClick);
        gameObject.transform.DOMoveZ(-2, 0.1f);
        Instantiate(Feedback, gameObject.transform);
        //Debug.Log("first click");
        //OnClickNimporte();
    }

    /*public void OnClickNimporte()
    {
        Debug.Log("à cliquer n'importe");
        //gameObject.transform.transform.DOComplete();
        //gameObject.transform.DOMoveZ(MoveInZ, .001f);
        //MoveInZ = 0;
        //gameObject.transform.DOMoveZ(MoveInZ, 1f);
        if (PopUpPrefab != null)
        {
            Debug.Log(gameObject);
            PopUpPrefab.transform.DOMoveZ(0, .001f);
            gameObject.transform.DOMoveZ(-1, .001f);
        }
    }*/


    public void Updatelife()
    {
        Textlife.text = $"{_life}/{_lifeMax}";

        float percent = (float)_life / (float)_lifeMax;
        ImageLife.fillAmount = percent;
    }
    public void Hit(int damage)
    {
        Croix.transform.DOComplete();
        Croix.transform.DOPunchScale(new Vector3(-0.01f, -0.01f, 0), 0.3f);
        _life -= damage;
       
        //MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney;

        if (_life <= 0)
        {
            _life = 0;
            GoDestroy();
        }

        Updatelife();
    }

    public void GoDestroy()
    {
        gameObject.transform.DOScale(0, 0.1f).OnComplete(RealDestroy);
        MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney * 10;
        Spawn_PopUp.Instance.LanceSpawn();
    }

    public void RealDestroy()
    {
        Destroy(gameObject);
    }
}
