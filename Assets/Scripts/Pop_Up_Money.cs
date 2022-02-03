using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Pop_Up_Money : MonoBehaviour
{
    public Sprite m_Sprite;
    private int _life;
    [SerializeField] private int _lifeMax = 100;
    public Text Textlife;
    public Image ImageLife;
    public Image ImagePopUp;
    public GameObject Croix;
    public GameObject Feedback;
    public Rigidbody2D rb;
    public int MoveInZ = -1;
    //public GameObject PopUpPrefab;
    //public bool isBoss;



    public static Pop_Up_Money Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {

        Debug.Log("bonjour c'est le popup moneyyyy");
        var i = Random.Range(0, 2);
        m_Sprite = Spawn_PopUp.Instance.popUpSprites[i];
        ImagePopUp.sprite = m_Sprite;
        _lifeMax = Spawn_PopUp.Instance._lifeOfPopUp * 5;
        _life = _lifeMax;
        Updatelife();

    }

    public void OnClickCroix()
    {
        //Spawn_PopUp.Instance.HasClickCroix();
        //Debug.Log("first click");
        Hit(MainGame.Instance.totalDPC);
        MainGame.Instance.compteurClick++;
        gameObject.transform.DOMoveZ(-3, 0.1f);
        Instantiate(Feedback, gameObject.transform);
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
        MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney * 5;
        MainGame.Instance.totalMoney += Spawn_PopUp.Instance.addMoney * 5;

        if (_life <= 0)
        {
            _life = 0;
            Spawn_PopUp.Instance.howManySpeDied++;
            GoDestroy();
}

        Updatelife();
    }

    public void GoDestroy()
    {
        gameObject.transform.DOScale(0, 0.1f).OnComplete(RealDestroy);
        MainGame.Instance.myMoney += Spawn_PopUp.Instance.addMoney * 100;
        MainGame.Instance.totalMoney += Spawn_PopUp.Instance.addMoney * 100;
    }

    public void RealDestroy()
    {
        Destroy(gameObject);
    }
}
