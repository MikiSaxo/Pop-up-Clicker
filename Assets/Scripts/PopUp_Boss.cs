using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUp_Boss : MonoBehaviour
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
    //public GameObject PopUpPrefab;
    //public bool isBoss;
    public GameObject Feedback;



    public static PopUp_Boss Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        //Debug.Log("yo le spawn de popup");
        Debug.Log("bonjour c'est le boss");
        var i = Random.Range(0, 2);
        m_Sprite = Spawn_PopUp.Instance.popUpSprites[i];
        ImagePopUp.sprite = m_Sprite;
        _lifeMax = Spawn_PopUp.Instance._lifeOfPopUp * 10;
        _life = _lifeMax;
        Updatelife();

    }

    public void OnClickCroix()
    {
        Sound_Script.Instance.PlayClick();
        //Spawn_PopUp.Instance.HasClickCroix();
        Hit(MainGame.Instance.totalDPC);
        MainGame.Instance.compteurClick++;
        gameObject.transform.DOMoveZ(-3, 0.1f);
        Instantiate(Feedback, gameObject.transform);
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
        gameObject.transform.DOMoveZ(-3, 0.1f);
        Croix.transform.DOComplete();
        Croix.transform.DOPunchScale(new Vector3(0.01f, 0.01f, 0), 0.3f);
        _life -= damage;
        //MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney;

        if (_life <= 0)
        {
            _life = 0;
            Spawn_PopUp.Instance.howManyBossDied++;
            GoDestroy();
        }

        Updatelife();
    }

    public void GoDestroy()
    {
        Sound_Script.Instance.PlayDestruction_PopUp();
        SpawnFeedBackGold.Instance.canSpawn = true;
        gameObject.transform.DOScale(0, 0.1f).OnComplete(RealDestroy);
        MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney * 100;
        MainGame.Instance.totalMoney += Spawn_PopUp.Instance.addMoney * 100;
        if (Spawn_PopUp.Instance.addNewPop <= 5)
        {
            Spawn_PopUp.Instance.PopUpAfterBoss();
            Debug.Log("New popup apres mort boss");
        }
    }

    public void RealDestroy()
    {
        Destroy(gameObject);
    }
}
