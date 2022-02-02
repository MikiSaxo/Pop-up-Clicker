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
    public GameObject FeedbackGold;
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
   
        
    }

    public void Update()
    {
        if (_life <= 0)
        {
            Debug.Log("spawn gold");
            Instantiate(FeedbackGold, gameObject.transform);
        }
    }

    public void OnClickCroix()
    {
        //Spawn_PopUp.Instance.HasClickCroix();
        Hit(MainGame.Instance.totalDPC);
        MainGame.Instance.compteurClick++;
        gameObject.transform.DOMoveZ(-2, 0.1f);
        //Instantiate(Feedback, gameObject.transform);

       
            //Debug.Log("first click");
            //OnClickNimporte();
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
        Croix.transform.DOPunchScale(new Vector3(-0.01f, -0.01f, 0), 0.3f);
        //Instantiate(FeedbackGold, gameObject.transform);
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
        //Instantiate(FeedbackGold, gameObject.transform);
        gameObject.transform.DOScale(0, 0.1f).OnComplete(RealDestroy);
        MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney * 10;
        MainGame.Instance.totalMoney += Spawn_PopUp.Instance.addMoney * 10;
        Spawn_PopUp.Instance.LanceSpawn();
    }

    public void RealDestroy()
    {
        Destroy(gameObject);
    }
}
